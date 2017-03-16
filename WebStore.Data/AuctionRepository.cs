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

        SqlConnection conn;
        SqlDataAdapter adp;
        DataSet ds;
        SqlCommand sqlc;

        public AuctionRepository()
        {
            conn = new SqlConnection("Data Source=ALUCARD;Initial Catalog=Repository;Integrated Security=True");
        }
        private void OpenCloseConnection()
        {
            conn.Open();
            sqlc.ExecuteNonQuery();
            conn.Close();
        }



        public IEnumerable<Auction> GetAllAuctions()
        {
            adp = new SqlDataAdapter("Select * from [Auction]", conn);
            ds = new DataSet();
            adp.Fill(ds);
            var myData = ds.Tables[0].AsEnumerable().Select(r => new Auction
            {

                Id = r.Field<int>("Id"),
                Name = r.Field<string>("Name"),
                Price = r.Field<double>("Price"),
                Seller = r.Field<string>("Seller"),
                Status = r.Field<string>("Status")
            });
            return myData.ToList();

        }




<<<<<<< HEAD
               new Auction
               {
                   Id = 4,
                   Name="Pokemon",
                   Price=69,
                   Buyer="Jovan",
                   Seller="Pera",
                   Status="Sold"
               }
            };
        }
=======
>>>>>>> b63d673b8d8602fdde19837486fe52cadd13c0fe

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
                   Name="Vanzemaljac",
                   Price=69,
                   Buyer="Jovan",
                   Seller="Pera",
                   Status="Sold"
               },
               new Auction
               {
                   Id = 5,
                   Name = "Frizbi",
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
                   Name = "Item 90",
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
                   Name="Item 4",
                   Price=69,
                   Buyer="Jovan",
                   Seller="Pera",
                   Status="Sold"
               },
               new Auction
               {
                   Id = 5,
                   Name = "Item 5",
                   Price=30,
                   Buyer="Jovan",
                   Seller="Pera",
                   Status="Sold"
               },
               new Auction
               {
                   Id = 6,
                   Name = "Item 6",
                   Price = 2000,
                   Buyer = "Pera",
                   Seller = "Goran",
                   Status = "Sold"
<<<<<<< HEAD
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
                   Name = "Crna majica",
                   Price = 2000,
                   Buyer = "Pera",
                   Seller = "Milan",
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
                   Name = "Item 3",
                   Price = 2,
                   Buyer = "Jovan",
                   Seller = "Pera",
                   Status = "Sold"

=======
>>>>>>> b63d673b8d8602fdde19837486fe52cadd13c0fe
               }
            };



        }

    }
}