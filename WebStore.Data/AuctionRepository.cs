using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.Contracts.Models;
using WebStore.Data.Contracts.RepositoryInterface;
namespace WebStore.Data
{
    public class AuctionRepository : IAuctionRepository
    {
        public IEnumerable<Auction> GetAllAuctions()
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
               }
            };
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





    }
}
