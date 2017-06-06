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
            

            if (ModelState.IsValid)
            {
                AuctionDto auction = new AuctionDto();
                auction.Name = newAuction.Name;
                auction.Price = newAuction.Price;
                auction.Seller = new UserDto();
                auction.Seller.UserName = Session["UserName"].ToString();
                auction.Description = newAuction.Description;
                auction.Image_Path = newAuction.Image_Path;

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