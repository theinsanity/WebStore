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

        //private string connectionString = "Data Source=desktop-utldqk4\\shiro;Initial Catalog=Repository;Integrated Security=True";
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }



        public User MapTableEnityToObject(IDataRecord record)
        {
            User entity = new User();
            
            entity.UserName = (string)record["UserName"];
            entity.Email = (string)record["Email"];
            entity.Password = (string)record["Password"];
            entity.Credit = (double)record["Credit"];


            return entity;
        }
        private List<User> CreateCommand(string queryString,
            string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<User> result = new List<User>();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        User act = new User();
                        act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }

                }
               

                return result;
            }
        }
        private List<User> GetUserEmailCommand(string connectionString, User user)
        {
            string queryString = "Select * from [User] where Email=@usremail";
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@usremail", user.Email);
                


                SqlDataReader reader = command.ExecuteReader();

                List<User> result = new List<User>();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        User act = new User();
                        act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }

                }
                return result;
            }


        }

        private List<User> GetUserUsernameCommand(string connectionString, User user)
        {
            string queryString = "Select * from [User] where UserName=@usrusername";
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@usrusername", user.UserName);



                SqlDataReader reader = command.ExecuteReader();

                List<User> result = new List<User>();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        User act = new User();
                        act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }

                }

                return result;
            }


        }
       

       


        public bool CheckUserEmail(User user)
        {
            List<User> Data = new List<User>();
            Data = GetUserEmailCommand(_connectionString, user);

            if (Data.Count() == 1) /* exists in db, return false */
                return false;
            else
            {
                return true;
            }
        }

        public bool CheckUserUsername(User user)
        {
            List<User> Data = new List<User>();
            Data = GetUserUsernameCommand(_connectionString, user);



            if (Data.Count() == 1) /* exists in db, return false */
                return false;
            else
            {
                return true;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            string query = "Select * from [User]";
            List<User> Data = new List<User>();

            Data = CreateCommand(query, _connectionString);

            return Data;

        }
       
       

    private void CreateCommand(
            string connectionString, User user)
        {
            string queryString = "Insert into [User](UserName, Email, Password, Credit) values(@username, @email, @password, 0)";

            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                

                command.ExecuteNonQuery();
                connection.Close();
                //  SqlDataReader reader = command.ExecuteReader();


            }
        }



        public void CreateUser(User user)
        {

           CreateCommand(_connectionString, user);

        }

    }
}
