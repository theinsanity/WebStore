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
    public class HomeController : Controller
    {
        

        private readonly IAuctionService _auctionService;
        public HomeController(IAuctionService auctionService) 
        {
            
            _auctionService = auctionService;
        }
        
        public ActionResult Index()
        {
            
            var auctions = _auctionService.GetAllAuctions();
            var user = new UserDto();
            user.UserName = "Pera";
            user.Credit = 10000;
            return View(new AuctionViewModel { Auctions = auctions ,UserName=user.UserName,Credit=user.Credit });
        }
        
        public ActionResult CreateAuction()
        {
            return RedirectToAction("Index", "CreateAuction");
        }

       /*
        public ActionResult Buy()
        {
            AuctionDto auction = new AuctionDto();
            auction.Buyer.UserName = "Pera";
            auction.Id =  Convert.ToInt32(Request["id"]);
            _auctionService.UpdateAuction(auction);

            return Content(auction.Id.ToString());
        }
        */

    }
}