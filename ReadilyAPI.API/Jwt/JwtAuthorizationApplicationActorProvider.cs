using Newtonsoft.Json;
using ReadilyAPI.API.Jwt;
using ReadilyAPI.Application;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.API
{
    public class JwtAuthorizationApplicationActorProvider : IApplicationActorProvider
    {
        private readonly string _authorizationHeader;
        private readonly ITokenStorage _tokenStorage;

        public JwtAuthorizationApplicationActorProvider(string authorizationHeader, ITokenStorage tokenStorage)
        {
            _authorizationHeader = authorizationHeader;
            _tokenStorage = tokenStorage;
        }

        public IApplicationActor GetActor()
        {
            if(_authorizationHeader == null || !_authorizationHeader.Contains("Bearer"))
            {
                return new UnauthorizedActor();
            }

            var data = _authorizationHeader.ToString().Split("Bearer ");

            if (data.Length < 2)
            {
                return new UnauthorizedActor();
            }

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(data[1].ToString());

            var claims = tokenObj.Claims;

            if (!_tokenStorage.TokenExists(claims.First(x => x.Type == "jti").Value))
            {
                return new UnauthorizedActor();
            }

            var email = claims.First(x => x.Type == "Email").Value;
            var id = claims.First(x => x.Type == "Id").Value;
            var username = claims.First(x => x.Type == "Username").Value;
            var useCases = claims.First(x => x.Type == "UseCases").Value;
            var firstName = claims.First(x => x.Type == "FirstName").Value;
            var lastName = claims.First(x => x.Type == "LastName").Value;

            List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

            return new Actor
            {
                Email = email,
                AllowedUseCases = useCaseIds,
                Id = int.Parse(id),
                Username = username,
                FirstName = firstName,
                LastName = lastName,
            };
        }
    }
}
