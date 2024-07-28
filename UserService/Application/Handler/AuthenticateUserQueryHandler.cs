using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserService.Application.Queries;
using UserService.Infrastructure.Repositories;

namespace UserService.Application.Handlers
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, string>
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.AuthenticateAsync(request.Username, request.Password);
            if (user == null)
            {
                return null;
            }
            return "fake-jwt-token";
        }
    }
}
