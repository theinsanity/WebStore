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
        SqlConnection conn;
        SqlDataAdapter adp;
        DataSet ds;
        SqlCommand sqlc;
      public UserRepository()
        {
            conn = new SqlConnection("Data Source=ALUCARD;Initial Catalog=Repository;Integrated Security=True");
        }
      private void OpenCloseConnection()
        {
            conn.Open();
            sqlc.ExecuteNonQuery();
            conn.Close();
        }



        public IEnumerable<User> GetAllUsers()
        {
            /*
              U SQL Adapteru proslediti Upit.
              Za sad radi testiranja vracamo listu
              TODO: Umesto liste -> Json
            */
            adp = new SqlDataAdapter("Select * from [User]", conn);
            ds = new DataSet();
            adp.Fill(ds);
            var myData = ds.Tables[0].AsEnumerable().Select(r => new User
            {
<<<<<<< HEAD
                UserName = r.Field<string>("UserName"),
                Password = r.Field<string>("Password"),
                Email = r.Field<string>("Email"),
                Credit = r.Field<double>("Credit")
            });
           return myData.ToList();
            
=======
                new User
                {
                    UserName= "pera",
                    Password="123",
                    Email = "pera@peran.com",
                    Credit = 1000
                }
              
            };
>>>>>>> afd43be49a46b45688c529871ba11f37fa537811
        }
    }
}
