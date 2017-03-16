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
        private void CreateCommand(
            string connectionString,Auction auction)
        {
            string queryString = "Insert into [Auction] (Name, Price, Buyer, Seller, Status) values(@name,@price,null,@seller,'Pending')";

            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@name", auction.Name);
                command.Parameters.AddWithValue("@price", auction.Price);
                command.Parameters.AddWithValue("@seller", auction.Seller);

                command.ExecuteNonQuery(); 
              //  SqlDataReader reader = command.ExecuteReader();
                

            }
        }
        private void UpdateCommand(string connectionString, Auction auction)
        {
            string queryString = "Update [Auction] set Buyer=@buyer,Status='Sold' where id=@id";
            using (SqlConnection connection = new SqlConnection(
                     connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@buyer", auction.Buyer);
                command.Parameters.AddWithValue("@id", auction.Id);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Auction> GetAllAuctions()
        {
            string query = "Select * from [Auction]";
            List<Auction> Data = new List<Auction>();
            Data = SelectCommand(query, ConnectionString);
            return Data;

        }
        public void CreateAuction(Auction auction)
        {
            //string query = "Insert into [Auction] (id,name,price,buyer,seller,status) values(21,"+ auction.Name +","+auction.Price+",null,"+auction.Seller+",'Pending'";
            CreateCommand(ConnectionString,auction);           
        }
        
        public void UpdateAuction(Auction auction)
        {
            UpdateCommand(ConnectionString,auction);
        }



        public IEnumerable<Auction> GetAllSold()
        {

            string query = "Select * from [Auction]";
            List<Auction> Data = new List<Auction>();
            Data = SelectCommand(query, ConnectionString);
            return Data;
        }
        public IEnumerable<Auction> GetAllBought()
        {

            string query = "Select * from [Auction]";
            List<Auction> Data = new List<Auction>();
            Data = SelectCommand(query, ConnectionString);
            return Data;


        }

    }
}