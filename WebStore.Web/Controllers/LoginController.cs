using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Services.Contracts.Dto;
using WebStore.Services.Contracts.ServiceInterface;
using WebStore.Web.Models;

namespace WebStore.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Login
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var usr = new UserDto();
                usr.UserName = user.UserName;
                usr.Password = user.Password;
                if (_userService.LoginValidation(usr))
                {
                    Session["UserId"] = _userService.GetUserId(usr).UserId;
                    //double credit = _userService.GetUserCredit(usr);


                    if (user.RememberMe == true)
                    {
                        HttpCookie cookie = new HttpCookie("UserInfo");
                        cookie["Name"] = usr.UserName;
                        cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie);
                    }

                    return RedirectToAction("Index", "Home", null);
                }
                else
                {

                    return Content("Login failed!");
                }
            }
            else
            {
                return Content("Login failed");
            }
        }
        public ActionResult Index()
        {
            var loginUser = new LoginViewModel();
            var cookie = Request.Cookies["UserInfo"];
            if(cookie == null)
            {
                return View(loginUser);
            }
            else
            {
                loginUser.UserName = cookie["Name"];
                return View(loginUser);
            }
            
        }
        public ActionResult Create()
        {
            return RedirectToAction("Index", "CreateAccount", null);
        }
    }
}