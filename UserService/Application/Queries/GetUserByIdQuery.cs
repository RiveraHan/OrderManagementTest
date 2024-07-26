using MediatR;
using UserService.Data;
using UserService.Models;

namespace UserService.Application.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<User>;

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly UserDbContext _context;

        public GetUserByIdQueryHandler(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}