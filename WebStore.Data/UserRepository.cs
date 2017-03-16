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
        private string ConnectionString = "Data Source=ALUCARD;Initial Catalog=Repository;Integrated Security=True";

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



        public IEnumerable<User> GetAllUsers()
        {
            string query = "Select * from [User]";
            List<User> Data = new List<User>();
            Data = CreateCommand(query, ConnectionString);
            return Data;

        }
    }
}
