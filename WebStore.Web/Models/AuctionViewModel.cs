using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.Services.Contracts.Dto;
namespace WebStore.Web.Models
{
    public class AuctionViewModel
    {
        public IEnumerable<AuctionDto> Auctions { get; set; }
        public IEnumerable<AuctionDto> AuctionsBought { get; set; }
        public IEnumerable<AuctionDto> AuctionsSold { get;  set; }

        public string Buyer { get; set; }
        public int Id { get; set; }
    }
}