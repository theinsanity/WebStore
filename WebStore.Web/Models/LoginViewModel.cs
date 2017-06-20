using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]        
        public string UserName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}