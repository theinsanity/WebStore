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


        private readonly string _connectionString;

        public AuctionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        
        public Auction MapTableEnityToObject(IDataRecord record)
        {
            var entity = new Auction
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                Price = (double)record["Price"],
                Seller = new User { UserName = (string)record["Seller"] },
                Buyer = new User()
            };
            if (record["Buyer"] == DBNull.Value)
            {
                entity.Buyer = null;
            }
            else
            {
                entity.Buyer.UserName = (string)record["Buyer"];
            }
            entity.Status = (string)record["Status"];
            return entity;
        }

        //Select queries

        //Select all 

        private IEnumerable<Auction> SelectCommand(string queryString,
            string connectionString)
        {
            using (var connection = new SqlConnection(
                       connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                var reader = command.ExecuteReader();
                var result = new List<Auction>();
                if (reader.HasRows != true)
                {
                    return result;
                }
                while (reader.Read())
                {
                    var act = MapTableEnityToObject(reader); ;
                    result.Add(act);

                }
                return result;
            }
        }

        public IEnumerable<Auction> GetAllAuctions()
        {
            const string query = "Select * from [Auction]";
            return SelectCommand(query, _connectionString);
        }

        //Select all sold

        private List<Auction> GetAllSoldCommand(string connectionString, Auction auction)
        {
            const string queryString = "Select * from [Auction] where Status=@st and Seller= @sl";
            using (var connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@st", auction.Status);
                command.Parameters.AddWithValue("@sl", auction.Seller.UserName);


                var reader = command.ExecuteReader();

                var result = new List<Auction>();
                if (reader.HasRows != true)
                {
                    return result;
                }
                while (reader.Read())
                {
                    var act = MapTableEnityToObject(reader); ;
                    result.Add(act);

                }
                return result;
            }
        }

        



        public IEnumerable<Auction> GetAllSold(Auction auction)
        {
            
           return GetAllSoldCommand(_connectionString, auction);
            
        }

        //Select all bought

        private IEnumerable<Auction> GetAllBoughtCommand(string connectionString, Auction auction)
        {
            const string queryString = "Select * from [Auction] where Status=@st and Buyer= @sl";
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@st", auction.Status);
                command.Parameters.AddWithValue("@sl", auction.Buyer.UserName);


                var reader = command.ExecuteReader();

                var result = new List<Auction>();
                if (reader.HasRows != true)
                {
                    return result;
                }
                
                    while (reader.Read())
                    {
                        var act = MapTableEnityToObject(reader);
                        result.Add(act);

                    }

                
                return result;
            }


        }


        public IEnumerable<Auction> GetAllBought(Auction auction)
        {

            return GetAllBoughtCommand(_connectionString, auction);
        }    
        

        //Insert queries

        private void CreateCommand(
            string connectionString, Auction auction)
        {
            const string queryString = "Insert into [Auction] (Name, Price, Buyer, Seller, Status) values(@name,@price,null,@seller,'Pending')";

            using (var connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@name", auction.Name);
                command.Parameters.AddWithValue("@price", auction.Price);
                command.Parameters.AddWithValue("@seller", auction.Seller.UserName);

                command.ExecuteNonQuery();



            }
        }

        public void CreateAuction(Auction auction)
        {
            CreateCommand(_connectionString, auction);
        }

        //Update queries

        private void UpdateCommand(string connectionString, Auction auction)
        {
            const string queryString = "Update [Auction] set Buyer=@buyer,Status='Sold' where id=@id";
            using (var connection = new SqlConnection(
                     connectionString))
            {
                connection.Open();

                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@buyer", auction.Buyer.UserName);
                command.Parameters.AddWithValue("@id", auction.Id);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAuction(Auction auction)
        {
            UpdateCommand(_connectionString, auction);
        }


    }
}