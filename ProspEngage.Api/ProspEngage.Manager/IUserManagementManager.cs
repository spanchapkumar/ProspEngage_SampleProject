﻿using ProspEngage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspEngage.Manager
{
    public interface IUserManagementManager
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
       
    }
}
