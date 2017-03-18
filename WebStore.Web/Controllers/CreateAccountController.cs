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

       [HttpPost]
       public ActionResult Create(CreateAccountViewModel newUser)
        {
            if (ModelState.IsValid == true)
            {
                /* check for passrwords */
                if (newUser.Password != newUser.RepeatPassword)
                {
                    return Content("Passwords arent correct"); 
                }
                UserDto user = new UserDto();
                user.UserName = newUser.UserName;
                user.Email = newUser.Email;
                user.Password = newUser.Password;
                /* check for email */
                try
                {
                    /* checking if email exists already in our db */
                    bool EmailCheck =_userService.CheckUserEmail(user);
                    if (EmailCheck == false)
                        return Content("Email exists!");
                }
                catch
                {
                    return Content("Check Email Error");
                }
                try
                {
                    /* checking if username already exists in our db */
                    bool UsernameCheck = _userService.CheckUserUsername(user);
                    if (UsernameCheck == false)
                        return Content("Username exists!");
                }
                catch
                {
                    return Content("Check Username Error");
                }
                try
                {
                    /* creating acc */
                    _userService.CreateUser(user);
                }
                catch
                {
                    return Content("Error while creating account");
                }
                /*if it all was successful, acc was created and redirecting to login page */
                return RedirectToAction("Index", "Login", null);

            }
            else
                return Content("Greska sa accom");
           
        }

    public ActionResult Index()
        {
            var newUser = new CreateAccountViewModel();
            return View(newUser);
        }
    }
}