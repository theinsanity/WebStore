﻿using System;
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

        public string UserName { get; set; }
        public double Credit { get; set; }
        public string Buyer { get; set; }
        public string Seller { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
    }
}