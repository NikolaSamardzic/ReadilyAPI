using Newtonsoft.Json;
using ReadilyAPI.Application;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation
{
    public class JwtAuthorizationApplicationActorProvider : IApplicationActorProvider
    {
        private readonly string _authorizationHeader;

        public JwtAuthorizationApplicationActorProvider(string authorizationHeader)
        {
            _authorizationHeader = authorizationHeader;
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

            var email = claims.First(x => x.Type == "Email").Value;
            var id = claims.First(x => x.Type == "Id").Value;
            var username = claims.First(x => x.Type == "Username").Value;
            var useCases = claims.First(x => x.Type == "UseCases").Value;

            List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

            return new Actor
            {
                Email = email,
                AllowedUseCases = useCaseIds,
                Id = int.Parse(id),
                Username = username,
            };
        }
    }
}
