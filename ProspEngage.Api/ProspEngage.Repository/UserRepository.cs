using ProspEngage.DataAccess;
using ProspEngage.Models;
using System.Collections.Generic;

namespace ProspEngage.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataAccess _dataAccess;

        public UserRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public UserDTO GetUserById(int id)
        {
            return _dataAccess.GetUserById(id);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _dataAccess.GetAllUsers();
        }

        public UserDTO CreateUser(UserDTO user)
        {
            return _dataAccess.CreateUser(user);
        }

        public void UpdateUser(UserDTO user)
        {
            _dataAccess.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _dataAccess.DeleteUser(id);
        }
    }
}
