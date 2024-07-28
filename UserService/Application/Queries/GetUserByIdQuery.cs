using MediatR;
using UserService.Domain.Models;

namespace UserService.Application.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }
}