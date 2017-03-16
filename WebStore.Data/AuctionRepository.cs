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





        public IEnumerable<Auction> GetAllSold()
        {
            return new List<Auction>
            {
                new Auction
                {
                    Id=1,
                    Name="Item1",
                    Price=10,
                    Buyer=null,
                    Seller="Pera",
                    Status="Pending"
               },
               new Auction {
                    Id=2,
                    Name="Item2",
                    Price=20,
                    Buyer=null,
                    Seller="Laza",
                    Status="Pending"


                },
               new Auction
               {
                   Id=3,
                   Name="Item3",
                   Price=30,
                   Buyer="Pera",
                   Seller="Laza",
                   Status="Bought"



               },

               new Auction
               {
                   Id = 4,
                   Name="Vibrator",
                   Price=69,
                   Buyer="Jovan",
                   Seller="Pera",
                   Status="Sold"
               },
               new Auction
               {
                   Id = 5,
                   Name = "Vazelin",
                   Price=30,
                   Buyer="Jovan",
                   Seller="Pera",
                   Status="Sold"
               },
               new Auction
               {
                   Id = 6,
                   Name = "Grobna parcela",
                   Price = 2000,
                   Buyer = "Pera",
                   Seller = "Goran",
                   Status = "Sold"
               },
               new Auction
               {
                   Id = 6,
                   Name = "Skin za Katarinu LOL",
                   Price = 20000,
                   Buyer = "Pera",
                   Seller = "Slobodan",
                   Status = "Sold"
               },
               new Auction
               {
                   Id = 7,
                   Name = "Crnac",
                   Price = 2000,
                   Buyer = "Pera",
                   Seller = "Ambasada Nigerije i Juznog Sudana",
                   Status = "Sold"
               },
               new Auction
               {
                   Id=8,
                   Name = "Uranijum U-32",
                   Price = 10000000,
                   Buyer = "Pera",
                   Seller = "Dima",
                   Status = "Pending"
               },
               new Auction
               {
                   Id = 9,
                   Name = "Tajlandjanka",
                   Price = 2,
                   Buyer = "Jovan",
                   Seller = "Pera",
                   Status = "Sold"

               }

            };
        }
        public IEnumerable<Auction> GetAllBought()
        {
            return new List<Auction>
            {
                new Auction
                {
                    Id=1,
                    Name="Item1",
                    Price=10,
                    Buyer=null,
                    Seller="Pera",
                    Status="Pending"
               },
               new Auction {
                    Id=2,
                    Name="Item2",
                    Price=20,
                    Buyer=null,
                    Seller="Laza",
                    Status="Pending"


                },
               new Auction
               {
                   Id=3,
                   Name="Item3",
                   Price=30,
                   Buyer="Pera",
                   Seller="Laza",
                   Status="Sold"



               },

               new Auction
               {
                   Id = 4,
                   Name="Vibrator",
                   Price=69,
                   Buyer="Jovan",
                   Seller="Pera",
                   Status="Sold"
               },
               new Auction
               {
                   Id = 5,
                   Name = "Vazelin",
                   Price=30,
                   Buyer="Jovan",
                   Seller="Pera",
                   Status="Sold"
               },
               new Auction
               {
                   Id = 6,
                   Name = "Grobna parcela",
                   Price = 2000,
                   Buyer = "Pera",
                   Seller = "Goran",
                   Status = "Sold"
               }
            };



        }

    }
}