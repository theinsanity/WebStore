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
        private readonly IAuctionService _auctionService;
        private readonly IUserService _userService;
        public UserController(IAuctionService auctionService, IUserService userService)
        {

            _auctionService = auctionService;
            _userService = userService;
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Login", null);
        }
        public ActionResult Index(AuctionViewModel avm)
        {
            AuctionDto act = new AuctionDto();
            act.Seller = new UserDto();
            act.Seller.UserName =Session["UserName"].ToString();
            avm.UserName = Session["UserName"].ToString();
            avm.Credit = Convert.ToDouble(_userService.GetUserCredit(new UserDto { UserName= avm.UserName}));

            var auctionsSold = _auctionService.GetAllSold(act);
            var auctionsBought = _auctionService.GetAllBought(act);
            return View(new AuctionViewModel {AuctionsBought = auctionsBought, AuctionsSold = auctionsSold, UserName = avm.UserName,Credit= avm.Credit });
        }
    }
}