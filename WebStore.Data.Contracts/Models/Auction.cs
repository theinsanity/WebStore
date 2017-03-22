using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Data.Contracts.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public double Price { get; set; }
        public User Buyer { get; set; }
        public User Seller { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Image_Path { get; set; }
        public DateTime Date_Added { get; set; }
        public DateTime Date_Purchased { get; set; }
    }
}
