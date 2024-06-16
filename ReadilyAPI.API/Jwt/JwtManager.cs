using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReadilyAPI.API.Jwt
{
    public class JwtManager
    {
        private readonly ReadilyContext _context;
        private readonly string _issuer;
        private readonly int _seconds;
        private readonly ITokenStorage _storage;
        private readonly string _secretKey;

        public JwtManager(
            ReadilyContext context, 
            string issuer, 
            int seconds, 
            ITokenStorage storage, 
            string secretKey)
        {
            _context = context;
            _issuer = issuer;
            _seconds = seconds;
            _storage = storage;
            _secretKey = secretKey;
        }

        public string MakeToken(string username, string password)
        {
            var user = _context.Users
                .Include(x=>x.Role)
                .ThenInclude(x=>x.RoleUseCases)
                .Include(x=>x.UserUseCases)
                .FirstOrDefault(x=>x.Username == username && x.IsActive && !x.IsBanned && x.EmailVerifiedAt.HasValue);

            if(user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var verified = BCrypt.Net.BCrypt.Verify(password, user.Password);
            
            if (user.Role == null || !user.Role.IsActive || !verified) 
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var userUseCases = user.Role.RoleUseCases.Select(x => x.UseCaseId).ToList();
            var useCasesToRemove = _context.UserUseCases.Where(x => x.UserId == user.Id && x.Status == false).Select(x => x.UseCaseId).ToList();
            var useCasesToAdd = _context.UserUseCases.Where(x => x.UserId == user.Id && x.Status).Select(x => x.UseCaseId ).ToList();

            userUseCases.RemoveAll(x => useCasesToRemove.Contains(x));
            userUseCases.AddRange(useCasesToAdd);

            int id = user.Id;
            string email = user.Email;
            string firstName = user.FirstName;
            string lastName = user.LastName;
            List<int> useCases = userUseCases.Distinct().ToList();

            var tokenId = Guid.NewGuid().ToString();
            
            _storage.AddToken(tokenId);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, tokenId, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss,_issuer,ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("Id", id.ToString()),
                new Claim("Username",username),
                new Claim("Email", email),
                new Claim("FirstName",firstName),
                new Claim("LastName", lastName),
                new Claim("UseCases", JsonConvert.SerializeObject(useCases))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(_seconds),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
