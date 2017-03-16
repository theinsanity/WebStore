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
    public class AuctionRepository : IAuctionRepository
    {
        private string ConnectionString = "Data Source=ALUCARD;Initial Catalog=Repository;Integrated Security=True";


        //SqlCommand sqlc = new SqlCommand();



        public Auction MapTableEnityToObject(IDataRecord record)
        { 
            Auction entity = new Auction();
            entity.Id = (int)record["Id"];
            entity.Name = (string)record["Name"];
            entity.Price = (double)record["Price"];
            entity.Seller = (string)record["Seller"];
            if (record["Buyer"] == DBNull.Value)
                entity.Buyer = string.Empty;
            else 
                entity.Buyer = (string)record["Buyer"];
            entity.Status = (string)record["Status"];
            return entity;
        }

        private  List<Auction> SelectCommand(string queryString,
            string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Auction> result = new List<Auction>();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        Auction act = new Auction();
                        act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }

                }
                return result;
            }
        }
        private void CreateCommand(string queryString,
            string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();

            }
        }

        public IEnumerable<Auction> GetAllAuctions()
        {
            string query = "Select * from [Auction]";
            List<Auction> Data = new List<Auction>();
            Data = SelectCommand(query, ConnectionString);
            return Data;

        }

        public IEnumerable<Auction> GetAllSold(User user)
        {
            string query = "Select * from [Auction] where status = sold and seller = user.Seller ";
            List<Auction> Data = new List<Auction>();
            Data = SelectCommand(query, ConnectionString);
            return Data;
           }
        public IEnumerable<Auction> GetAllBought(User user)
        {
            string query = "Select * from [Auction] where status = sold and buyer = user.Buyer";
            List<Auction> Data = new List<Auction>();
            Data = SelectCommand(query, ConnectionString);
            return Data;
        }
    }
}
