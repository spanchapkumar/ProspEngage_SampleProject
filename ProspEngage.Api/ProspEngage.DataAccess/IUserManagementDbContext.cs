using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProspEngage.Models;

namespace ProspEngage.DataAccess
{
    public interface IUserManagementDbContext
    {

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
