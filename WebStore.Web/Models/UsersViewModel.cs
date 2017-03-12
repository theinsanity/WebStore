using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.Services.Contracts.Dto;

namespace WebStore.Web.Models
{
    public class UsersViewModel
    {
       public IEnumerable<UserDto> Users { get; set; }
    }
}