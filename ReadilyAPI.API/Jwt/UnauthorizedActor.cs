using ReadilyAPI.Application;

namespace ReadilyAPI.API.Jwt
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Username => "unauthorized";

        public string Email => "";

        public string FirstName => "unauthorized";

        public string LastName => "unauthorized";

        public IEnumerable<int> AllowedUseCases => new List<int> { };
    }
}
