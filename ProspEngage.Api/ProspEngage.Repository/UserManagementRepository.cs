using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProspEngage.DataAccess;
using ProspEngage.Models;

namespace ProspEngage.Repository
{
    public class UserManagementRepository: IUserManagerRepository
    {
        private readonly IUserManagementDbContext _dbContext;

        public UserManagementRepository(IUserManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _dbContext.GetUserByIdAsync(userId);
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _dbContext.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _dbContext.DeleteUserAsync(userId);
        }
    }
}
