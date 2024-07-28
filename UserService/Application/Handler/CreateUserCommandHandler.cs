using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserService.Application.Commands;
using UserService.Infrastructure.Repositories;
using UserService.Domain.Models;

namespace UserService.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            };

            await _userRepository.AddUserAsync(user);
            return user.Id;
        }
    }
}
