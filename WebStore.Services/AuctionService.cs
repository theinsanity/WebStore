using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.Contracts.RepositoryInterface;
using WebStore.Services.Contracts.Dto;
using WebStore.Services.Contracts.ServiceInterface;
using WebStore.Data.Contracts.Models;
namespace WebStore.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public IEnumerable<AuctionDto> GetAllAuctions()
        {
            var auctionDtos = new List<AuctionDto>();
            foreach (Auction auction in _auctionRepository.GetAllAuctions())
            {
                if (auction.Status == "Pending")
                {
                    
                    auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price,Seller_Id = auction.Seller_Id ,Image_Path = auction.Image_Path});
                }
                    
            }
            return auctionDtos;

        }
        public void CreateAuction(AuctionDto auction)
        {
            Auction act = new Auction();
            act.Name = auction.Name;
            act.Price = auction.Price;
            act.Seller_Id = auction.Seller_Id;
            act.Description = auction.Description;
            act.Image_Path = auction.Image_Path;
            /*
            act.Date_Added = DateTime.Now;
            act.Date_Purchased = null;
            */
           _auctionRepository.CreateAuction(act);
        }
        public void UpdateAuction (AuctionDto auction)
        {
            Auction act = new Auction();
            act.Id = auction.Id;
            act.Buyer_Id = auction.Buyer_Id;
           
            _auctionRepository.UpdateAuction(act);


        }


        public IEnumerable<AuctionDto> GetAllSold(AuctionDto act)
        {

            Auction auct = new Auction();
            auct.Seller_Id = act.Seller_Id;
            auct.Status = "Sold";


            var auctionDtos = new List<AuctionDto>();
        
            foreach (Auction auction in _auctionRepository.GetAllSold(auct))
            {
                
                    auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price, Buyer_Id=auction.Buyer_Id });
            }
            return auctionDtos;

        }

        public IEnumerable<AuctionDto> GetAllBought(AuctionDto act)
        {
            Auction auct = new Auction();
            auct.Buyer_Id = act.Seller_Id;
            auct.Status = "Sold";

            var auctionDtos = new List<AuctionDto>();

            foreach (Auction auction in _auctionRepository.GetAllBought(auct))
            {
                auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price, Seller_Id =  auction.Seller_Id});
            }
            return auctionDtos;

        }
        public AuctionDto FindAuction(int id)
        {
            var auction = new AuctionDto();
            var auct = _auctionRepository.FindAuction(id);
            auction.Id = auct.Id;
            auction.Name = auct.Name;
            auction.Price = auct.Price;
            auction.Buyer_Id = auct.Buyer_Id;

            auction.Description = auct.Description;
            auction.Image_Path = auct.Image_Path;
            auction.Date_Purchased = auct.Date_Purchased;
            auction.Date_Added = auct.Date_Added;


            auction.Seller_Id = auct.Seller_Id;
            auction.Price = auct.Price;

            return auction;

        }
        public void DeleteAuction(AuctionDto auction)
        {
            Auction act = new Auction();
            act.Id = auction.Id;

            _auctionRepository.DeleteAuction(act);


        }
        public IEnumerable<AuctionDto> GetAllUsersAuctions(AuctionDto act)
        {
            Auction auct = new Auction();
            
            auct.Seller_Id = act.Seller_Id;


            var auctionDtos = new List<AuctionDto>();

            foreach (Auction auction in _auctionRepository.GetAllUsersAuctions(auct))
            {
                auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price });
            }
            return auctionDtos;

        }


    }
}