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
        public UserDto Buyer { get; set; }
        public UserDto Seller { get; set; }
        public string Status { get; set; }
    }
}
