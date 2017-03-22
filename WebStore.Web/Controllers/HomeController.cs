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
        /*
        
        public HomeController(IUserService userService)
        {

            _userService = userService;
        }
        */
        public ActionResult Index()
        {
            
            var auctions = _auctionService.GetAllAuctions();
            var user = new UserDto();
            user.UserName = Session["UserName"].ToString();
            user.Credit = Convert.ToDouble(Session["Credit"]);
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


            if (Convert.ToDouble(Session["Credit"]) - auction.Price >= 0 && auction.Seller.UserName != Session["UserName"].ToString())
            {
                auction.Buyer = new UserDto();
                auction.Buyer.UserName = Session["UserName"].ToString();

                var user = new UserDto();
                user.UserName = Session["UserName"].ToString();
                user.Credit = Convert.ToDouble(Session["Credit"]);
                

                _userService.UpdateUser(user, auction);              
                _auctionService.UpdateAuction(auction);

                var user1 = new UserDto();
                user1.UserName = Session["UserName"].ToString();
                double credit = _userService.GetUserCredit(user1);
                Session["Credit"] = credit;

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
            return View(new ItemsViewModel {Name=auction.Name,Price=auction.Price ,Seller=auction.Seller ,Date_Added=auction.Date_Added, Description=auction.Description, Image_Path=auction.Image_Path});
        }

    }
}