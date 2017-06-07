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
            if (ModelState.IsValid)
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
               
                
                try
                {
                 
                    if (_userService.CheckUserEmail(user))
                        return Content("Email exists!");
                }
                catch(Exception e)
                {
                    throw e;
                }
                
                try
                {
                    
                    bool UsernameCheck = _userService.CheckUserUsername(user);
                    if (UsernameCheck)
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