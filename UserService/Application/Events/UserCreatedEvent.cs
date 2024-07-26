namespace UserService.Application.Events
{
    public class UserCreatedEvent
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
    }
}
