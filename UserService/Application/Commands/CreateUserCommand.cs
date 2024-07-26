using MassTransit;
using MediatR;
using UserService.Application.Events;
using UserService.Data;
using UserService.Models;

namespace UserService.Application.Commands
{
    public record CreateUserCommand(string UserName, string Password) : IRequest<int>;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly UserDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateUserCommandHandler(UserDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { UserName = request.UserName, Password = request.Password };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            var userCreatedEvent = new UserCreatedEvent { UserId = user.Id, UserName = user.UserName };
            await _publishEndpoint.Publish(userCreatedEvent, cancellationToken);

            return user.Id;
        }
    }

}