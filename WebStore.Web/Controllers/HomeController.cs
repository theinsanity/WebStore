using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStore.Services.Contracts.Dto;
using WebStore.Services.Contracts.ServiceInterface;
using WebStore.Web.Models;

namespace WebStore.Web.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly IAuctionService _auctionService;
        private readonly IUserService _userService;
        public HomeController(IAuctionService auctionService, IUserService userService) 
        {
            
            _auctionService = auctionService;
            _userService = userService;
        }
        
        public ActionResult Index()
        {
            
            var auctions = _auctionService.GetAllAuctions();

            foreach(var auction in auctions)
            {
                auction.BoSName = _userService.GetUserById(new UserDto { UserId = auction.Seller_Id }).UserName;
            }

            var user = new UserDto();
            user.UserName =  _userService.GetUserById(new UserDto { UserId = Convert.ToInt32(Session["UserId"]) }).UserName;
            user.Credit = _userService.GetUserCredit(new UserDto { UserName = user.UserName });
            return View(new AuctionViewModel { Auctions = auctions ,UserName=user.UserName,Credit=user.Credit });
        }
        
        public ActionResult CreateAuction()
        {
            return RedirectToAction("Index", "CreateAuction");
        }

        
        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var auction = _auctionService.FindAuction(id.Value);

            var usr = new UserDto();

            usr.UserName = _userService.GetUserById(new UserDto { UserId = Convert.ToInt32(Session["UserId"]) }).UserName;
            usr.Credit = _userService.GetUserCredit(new UserDto { UserName = usr.UserName });

            if (Convert.ToDouble(usr.Credit) - auction.Price >= 0 && auction.Seller_Id != Convert.ToInt32(Session["UserId"]))
            {
                auction.Buyer_Id = Convert.ToInt32(Session["UserId"]);

                var user = new UserDto();
                user.UserName = usr.UserName;
                user.Credit = Convert.ToDouble(usr.Credit);
                user.UserId = Convert.ToInt32(Session["UserId"]);


                _userService.UpdateUser(user, auction);              
                _auctionService.UpdateAuction(auction);

                return RedirectToAction("Index", "Home", null);

            }
            else
            {
                return Content("Not enough credit");
            }
        }

        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var auction = _auctionService.FindAuction(id.Value);
            string bname = _userService.GetUserById(new UserDto { UserId = auction.Seller_Id }).UserName;
            return View(new ItemsViewModel {Name=auction.Name,Price=auction.Price ,BoSName=bname ,Date_Added=auction.Date_Added, Description=auction.Description, Image_Path=auction.Image_Path});
        }

    }
}