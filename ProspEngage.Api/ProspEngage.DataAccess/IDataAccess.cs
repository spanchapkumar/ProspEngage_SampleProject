using ProspEngage.Models;
using System.Collections.Generic;

namespace ProspEngage.DataAccess
{
    public interface IDataAccess
    {
        UserDTO GetUserById(int id);
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO CreateUser(UserDTO user);
        void UpdateUser(UserDTO user);
        void DeleteUser(int id);
    }
}
