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



        //Maping

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

        //Select queries

        //Select all 

        private List<Auction> SelectCommand(string queryString,
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

        public IEnumerable<Auction> GetAllAuctions()
        {
            string query = "Select * from [Auction]";
            List<Auction> Data = new List<Auction>();
            Data = SelectCommand(query, ConnectionString);
            return Data;

        }

        //Select all sold

        private List<Auction> GetAllSoldCommand(string connectionString, Auction auction)
        {
            string queryString = "Select * from [Auction] where Status=@st and Seller= @sl";
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@st", auction.Status);
                command.Parameters.AddWithValue("@sl", auction.Seller);


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



        public IEnumerable<Auction> GetAllSold(Auction auction)
        {
            List<Auction> Data = new List<Auction>();
            Data = GetAllSoldCommand(ConnectionString, auction);
            return Data;
        }

        //Select all bought

        private List<Auction> GetAllBoughtCommand(string connectionString, Auction auction)
        {
            string queryString = "Select * from [Auction] where Status=@st and Buyer= @sl";
            using (SqlConnection connection = new SqlConnection(
                      connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@st", auction.Status);
                command.Parameters.AddWithValue("@sl", auction.Buyer);


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


        public IEnumerable<Auction> GetAllBought(Auction auction)
        {
            List<Auction> Data = new List<Auction>();
            Data = GetAllBoughtCommand(ConnectionString, auction);
            return Data;
        }

        //Insert queries

        private void CreateCommand(
            string connectionString, Auction auction)
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

        public void CreateAuction(Auction auction)
        {
            CreateCommand(ConnectionString, auction);
        }

        //Update queries

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

        public void UpdateAuction(Auction auction)
        {
            UpdateCommand(ConnectionString, auction);
        }


    }
}