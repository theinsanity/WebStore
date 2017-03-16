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
    public class CreateAuctionController : Controller
    {
        private readonly IAuctionService _auctionService;
        public CreateAuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpPost]
        public ActionResult Create(CreateAuctionViewModel newAuction)
        {
            

            if (ModelState.IsValid == true)
            {
                AuctionDto auction = new AuctionDto();
                auction.Name = newAuction.Name;
                auction.Price = newAuction.Price;
                auction.Seller = "Prodavac101";
                try
                {
                    _auctionService.CreateAuction(auction);
                }
                catch
                {
                    return Content("Insert error");
                }


                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                return Content("Error");
            }
        }

        // GET: CreateAuction
        public ActionResult Index()
        {
            return View();
        }
    }
}