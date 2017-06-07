using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Services.Contracts.ServiceInterface;
using WebStore.Web.Models;
using WebStore.Services.Contracts.Dto;

namespace WebStore.Web.Controllers
{
    public class CreditController : Controller
    {
        private readonly IAuctionService _auctionService;
        private readonly IUserService _userService;
        public CreditController(IAuctionService auctionService, IUserService userService)
        {

            _auctionService = auctionService;
            _userService = userService;
        }


        // GET: Credit
        public ActionResult Index(CreditViewModel mv)
        {
            mv.UserName = _userService.GetUserById(new UserDto { UserId = Convert.ToInt32(Session["UserId"]) }).UserName;
            mv.Credit = Convert.ToDouble(_userService.GetUserCredit(new UserDto {UserName = mv.UserName }));
            return View(new CreditViewModel { UserName = mv.UserName, Credit = mv.Credit });
        }
    }
}