using MediatR;

namespace UserService.Application.Queries
{
    public class AuthenticateUserQuery : IRequest<string>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
