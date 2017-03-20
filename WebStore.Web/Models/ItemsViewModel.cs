using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.Services.Contracts.Dto;
namespace WebStore.Web.Models
{
    public class ItemsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public UserDto Seller { get; set; }
        
    }
}