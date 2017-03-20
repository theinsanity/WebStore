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
        public ActionResult Login(LoginViewModel user)
        {
            var usr = new UserDto();
            usr.UserName = user.UserName;
            usr.Password = user.Password;
            if (_userService.LoginValidation(usr))
            {
                Session["UserName"] = user.UserName;
                return RedirectToAction("Index", "Home", null);
            }
            else
            {

                return Content("Login failed!");
            }
        }
        public ActionResult Index()
        {
            var loginUser = new LoginViewModel();
            return View(loginUser);
        }
        public ActionResult Create()
        {
            return RedirectToAction("Index", "CreateAccount", null);
        }
    }
}