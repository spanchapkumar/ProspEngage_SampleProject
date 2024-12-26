using ProspEngage.Models;
using ProspEngage.Repository;
using System.Collections.Generic;

namespace ProspEngage.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserDTO CreateUser(UserDTO user)
        {
            return _userRepository.CreateUser(user);
        }

        public void UpdateUser(UserDTO user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
