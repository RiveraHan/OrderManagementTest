using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserService.Application.Queries;
using UserService.Infrastructure.Repositories;
using UserService.Domain.Models;

namespace UserService.Application.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(request.UserId);
        }
    }
}
