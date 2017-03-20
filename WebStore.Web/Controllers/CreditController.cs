using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Web.Models;

namespace WebStore.Web.Controllers
{
    public class CreditController : Controller
    {
        // GET: Credit
        public ActionResult Index(CreditViewModel mv)
        {
            mv.UserName = Session["UserName"].ToString();
            mv.Credit = Convert.ToDouble(Session["Credit"]);
            return View(new CreditViewModel { UserName = mv.UserName, Credit = mv.Credit });
        }
    }
}