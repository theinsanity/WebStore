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
        public UserController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Login", null);
        }
        public ActionResult Index()
        {
            UserDto user = new UserDto();
            user.UserName = "Pera";
            var auctionsSold = _auctionService.GetAllSold(user);
            var auctionsBought = _auctionService.GetAllBought(user);
            return View(new AuctionViewModel {AuctionsBought = auctionsBought, AuctionsSold = auctionsSold });
        }
    }
}