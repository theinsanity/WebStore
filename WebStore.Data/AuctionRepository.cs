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



               }
            };
        }



    }
}
