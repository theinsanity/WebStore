using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var LoggedUser = "Pera";
            var auctions = _auctionService.GetAllAuctions();
            return View(new AuctionViewModel { Auctions = auctions });
        }
        
        public ActionResult CreateAuction()
        {
            return RedirectToAction("Index", "CreateAuction");
        }

    }
}