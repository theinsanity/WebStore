using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Web.Models
{
    public class CreateAuctionViewModel
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string UserName { get; set; }
        public double Credit { get; set; }

    }
}