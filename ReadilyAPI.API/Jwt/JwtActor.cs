using ReadilyAPI.Application;

namespace ReadilyAPI.API.Jwt
{
    public class JwtActor : IApplicationActor
    {
        public int Id {get; set;}

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
