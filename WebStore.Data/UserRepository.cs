using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.Contracts.Models;
using WebStore.Data.Contracts.RepositoryInterface;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebStore.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        


        public User MapTableEnityToObject(IDataRecord record)
        {
            var entity = new User();
            entity.UserId = (int)record["UserId"];
            entity.UserName = (string)record["UserName"];
            entity.Email = (string)record["Email"];
            entity.Password = (string)record["Password"];
            entity.Credit = (double)record["Credit"];
            
            return entity;
        }

        private List<User> CreateCommand(string queryString,
            string connectionString)
        {
            using (var connection = new SqlConnection(
                       connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                var reader = command.ExecuteReader();

                var result = new List<User>();
                if (reader.HasRows != true) return result;

                while (reader.Read())
                {
                    var act = new User();
                    act = MapTableEnityToObject(reader);
                    result.Add(act);
                  
                }
             return result;
            }
        }

        private List<User> GetUserEmailCommand(string connectionString, User user)
        {
            string queryString = "Select * from [User] where Email=@usremail";
            using (var connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@usremail", user.Email);

                var reader = command.ExecuteReader();

                var result = new List<User>();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        var act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }
                }
                return result;
           }

        }

        private List<User> GetUserUsernameCommand(string connectionString, User user)
        {
            string queryString = "Select * from [User] where UserName=@usrusername";
            using (var connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@usrusername", user.UserName);

                var reader = command.ExecuteReader();

                var result = new List<User>();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        var act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }

                }

                return result;
            }


        }

        private List<User> GetUserIdCommand(string connectionString, User user)
        {
            string queryString = "Select * from [User] where UserId=@usrId";
            using (var connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@usrId", user.UserId);

                var reader = command.ExecuteReader();

                var result = new List<User>();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        var act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }

                }

                return result;
            }


        }

        public User GetUserByEmail(User user)
        {
            var data = GetUserEmailCommand(_connectionString, user);
            return data.FirstOrDefault();          
        }
        public User GetUserById(User user)
        {
            var data = GetUserIdCommand(_connectionString, user);
            return data.FirstOrDefault();
        }
        public User GetUserByUsername(User user)
        {
            var data = GetUserUsernameCommand(_connectionString, user);
            return data.FirstOrDefault();
        }
      
        public IEnumerable<User> GetAllUsers()
        {
            string query = "Select * from [User]";
            return CreateCommand(query, _connectionString);

        }



        private void CreateCommand(
                string connectionString, User user)
        {
            string queryString = "Insert into [User](UserName, Email, Password, Credit) values(@username, @email, @password, 0)";

            using (var connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void CreateUser(User user)
        {

            CreateCommand(_connectionString, user);

        }
                
        private void UpdateCommand(string connectionString, User user)
        {
            const string queryString = "Update [User] set Credit=@credit where UserId=@usrid";
            using (var connection = new SqlConnection(
                     connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@credit", user.Credit);
                command.Parameters.AddWithValue("@usrid", user.UserId);
                command.ExecuteNonQuery();
            }
        }
        public void UpdateUser(User user,User user1)
        {
            UpdateCommand(_connectionString, user);
            UpdateCommand(_connectionString, user1);
        }
    }
}
