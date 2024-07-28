using System.Threading.Tasks;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> AuthenticateAsync(string username, string password);
        Task<User> GetUserByIdAsync(int id);
    }
}
