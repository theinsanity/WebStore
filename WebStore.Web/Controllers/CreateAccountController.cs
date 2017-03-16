using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Services.Contracts.ServiceInterface;
using WebStore.Services.Contracts.Dto;
using WebStore.Web.Models;
namespace WebStore.Web.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly IUserService _userService;
        public CreateAccountController(IUserService userService)
        {
            _userService = userService;
        }

        
        /*[HttpPost]
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

        }*/
       [HttpPost]
       public ActionResult Create(CreateAcccountViewModel newUser)
        {
            if (ModelState.IsValid == true) 
            {
                /* check for passrwords */
                if (newUser.Password != newUser.RepeatPassword)
                {
                    return Content("Passwords arent correct");
                }
                /* add to database */
                return RedirectToAction("Index", "Login", null);
            }
            else
            {
                return Content("Ne valja");
            }
        }
        public ActionResult Index()
        {
            var newUser = new CreateAcccountViewModel();
            return View(newUser);
        }
    }
}