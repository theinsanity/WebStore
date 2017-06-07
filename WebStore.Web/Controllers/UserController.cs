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
            act.Seller_Id= Convert.ToInt32(Session["UserId"]);
            avm.UserName = _userService.GetUserById(new UserDto { UserId = Convert.ToInt32(Session["UserId"]) }).UserName;
            avm.Credit = Convert.ToDouble(_userService.GetUserCredit(new UserDto { UserName= avm.UserName}));

            var auctionsSold = _auctionService.GetAllSold(act);

            foreach (var auction in auctionsSold)
            {               

                auction.BoSName = _userService.GetUserById(new UserDto { UserId = (int)auction.Buyer_Id }).UserName;
            }


            var auctionsBought = _auctionService.GetAllBought(act);


            foreach (var auction in auctionsBought)
            {
                auction.BoSName = _userService.GetUserById(new UserDto { UserId = auction.Seller_Id }).UserName;
            }


            return View(new AuctionViewModel {AuctionsBought = auctionsBought, AuctionsSold = auctionsSold, UserName = avm.UserName,Credit= avm.Credit });
        
            
            }
    }
}