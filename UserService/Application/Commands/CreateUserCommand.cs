using MediatR;

namespace UserService.Application.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
