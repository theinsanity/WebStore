using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Services.Contracts.Dto;
using WebStore.Services.Contracts.ServiceInterface;

namespace WebStore.Web.Controllers
{
    public class CreateAuctionController : Controller
    {
        private readonly IUserService _userService;
        public CreateAuctionController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Create()
        {
            AuctionDto auction = new AuctionDto();
            auction.Price = Convert.ToDouble(Request["price"]);
            auction.Seller = "Pera";
            
            return RedirectToAction("Index", "Home", null);
        }

        // GET: CreateAuction
        public ActionResult Index()
        {
            return View();
        }
    }
}