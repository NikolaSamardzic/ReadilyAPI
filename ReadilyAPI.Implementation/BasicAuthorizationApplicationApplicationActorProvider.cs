using ReadilyAPI.Application;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation
{
    public class BasicAuthorizationApplicationApplicationActorProvider : IApplicationActorProvider
    {
        private readonly string _authorizationHeader;
        private readonly ReadilyContext _context;

        public BasicAuthorizationApplicationApplicationActorProvider(string authorizationHeader, ReadilyContext context)
        {
            _authorizationHeader = authorizationHeader;
            _context = context;
        }

        public IApplicationActor GetActor()
        {
            if(_authorizationHeader == null || !_authorizationHeader.Contains("Basic"))
            {
                return new UnauthorizedActor();
            }

            var base64Data = _authorizationHeader.Split(" ")[1];

            var bytes = Convert.FromBase64String(base64Data);

            var decodedCredentials = System.Text.Encoding.UTF8.GetString(bytes);

            if (decodedCredentials.Split(":").Length < 2)
            {
                throw new InvalidOperationException("invalid Basic authorization header.");
            }

            string username = decodedCredentials.Split(":")[0];
            string password = decodedCredentials.Split(":")[1];

            User user = _context.Users.FirstOrDefault(x=>x.Username == username && x.Password == password);

            if (user == null) { 
                return new UnauthorizedActor();
            }

            return new Actor
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Username = user.Username,
            };
        }

        
    }
}
