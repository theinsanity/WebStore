using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebStore.Web.Models
{
    public class CreateAccountViewModel
    {
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string UserName { get; set; }
        [RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$")]
        [Required]
        public string Email { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Password { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string RepeatPassword { get; set; }
    }
}