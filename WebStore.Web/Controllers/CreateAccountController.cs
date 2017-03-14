using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Services.Contracts.ServiceInterface;
using WebStore.Services.Contracts.Dto;
namespace WebStore.Web.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly IUserService _userService;
        public CreateAccountController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpPost]
        public ActionResult RedirectToLoginPage()
        {
            UserDto user = new UserDto();
            user.UserName = Request["username"];
            user.Email = Request["email"];
            user.Password = Request["password"];
            user.Credit = 1000;
            string condition = _userService.CheckUser(user); 
          
            if(user.Password != Request["repeat_password"])
                return Content("Passwords must match!");
            if (condition == "Success")
                return RedirectToAction("Index", "Login", null);
            else
                return Content(condition);

        }
       
        public ActionResult Index()
        {
            return View();
        }
    }
}