using ProspEngage.DataAccess;
using ProspEngage.Models;
using ProspEngage.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspEngage.Manager
{
    public class UserManagementManager : IUserManagementManager
    {
        private readonly IUserManagerRepository _userRepository;

        public UserManagementManager(IUserManagerRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}
