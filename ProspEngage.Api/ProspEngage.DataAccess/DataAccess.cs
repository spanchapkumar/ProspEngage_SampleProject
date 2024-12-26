using ProspEngage.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProspEngage.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly string _connectionString = "Server=.;Database=ProspEngageDB;Trusted_Connection=True;TrustServerCertificate=True;"; // Replace with your connection string

        public UserDTO GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetUserById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["Name"],
                                Age = (int)reader["Age"]
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetAllUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserDTO
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["Name"],
                                Age = (int)reader["Age"]
                            });
                        }
                    }
                }
            }
            return users;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CreateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Age", user.Age);

                    SqlParameter outputIdParam = new SqlParameter("@ID", SqlDbType.Int);
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    command.ExecuteNonQuery();
                    user.ID = (int)outputIdParam.Value;
                }
            }
            return user;
        }

        public void UpdateUser(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", user.ID);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Age", user.Age);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
