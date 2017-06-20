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
    public class ManageAuctionsController : Controller
    {


        private readonly IAuctionService _auctionService;
        private readonly IUserService _userService;
        public ManageAuctionsController(IAuctionService auctionService, IUserService userService)
        {

            _auctionService = auctionService;
            _userService = userService;
        }


        // GET: ManageAuctions
        public ActionResult Index()
        {
            var auct = new AuctionDto();
            auct.Seller_Id = Convert.ToInt32(Session["UserId"]);

            var user = new UserDto();
            user.UserName = _userService.GetUserById(new UserDto { UserId = Convert.ToInt32(Session["UserId"]) }).UserName;
            user.Credit = _userService.GetUserCredit(new UserDto { UserName = user.UserName });

            var auctions = _auctionService.GetAllUsersAuctions(auct);



            return View(new AuctionViewModel { Auctions = auctions, UserName = user.UserName, Credit = user.Credit, UserId = Convert.ToInt32(Session["UserId"]) });
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var auction = _auctionService.FindAuction(id.Value);

          
                _auctionService.DeleteAuction(auction);
                return RedirectToAction("Index", "Home", null);

            



        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var auction = _auctionService.FindAuction(id.Value);
            string bname = _userService.GetUserById(new UserDto { UserId = auction.Seller_Id }).UserName;
            return View(new ItemsViewModel { Name = auction.Name, Price = auction.Price, BoSName = bname, Date_Added = auction.Date_Added, Description = auction.Description, Image_Path = auction.Image_Path });
        }


    }
}