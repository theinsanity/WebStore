using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Services.Contracts.Dto
{
    public class AuctionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Buyer { get; set; }
        public string Seller { get; set; }
        public string Status { get; set; }
    }
}
