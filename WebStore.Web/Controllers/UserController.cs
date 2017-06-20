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
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}