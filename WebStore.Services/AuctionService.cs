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
                    
                    auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price,Seller = new UserDto {UserName = auction.Seller.UserName } });
                }
                    
            }
            return auctionDtos;

        }
        public void CreateAuction(AuctionDto auction)
        {
            Auction act = new Auction();
            act.Name = auction.Name;
            act.Price = auction.Price;
            act.Seller = new User();
            act.Seller.UserName = auction.Seller.UserName;
           _auctionRepository.CreateAuction(act);
        }
        public void UpdateAuction (AuctionDto auction)
        {
            Auction act = new Auction();
            act.Id = auction.Id;
            act.Buyer.UserName = auction.Buyer.UserName;
            _auctionRepository.UpdateAuction(act);


        }


        public IEnumerable<AuctionDto> GetAllSold(AuctionDto act)
        {

            Auction auct = new Auction();
            auct.Seller = new User();
            auct.Seller.UserName = act.Seller.UserName;
            auct.Status = "Sold";


            var auctionDtos = new List<AuctionDto>();
        
            foreach (Auction auction in _auctionRepository.GetAllSold(auct))
            {
                
                    auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price, Buyer = new UserDto { UserName = auction.Buyer.UserName } });
            }
            return auctionDtos;

        }

        public IEnumerable<AuctionDto> GetAllBought(AuctionDto act)
        {
            Auction auct = new Auction();
            auct.Buyer = new User();
            auct.Buyer.UserName = act.Seller.UserName;
            auct.Status = "Sold";

            var auctionDtos = new List<AuctionDto>();

            foreach (Auction auction in _auctionRepository.GetAllBought(auct))
            {
                auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price, Seller = new UserDto {UserName = auction.Seller.UserName } });
            }
            return auctionDtos;

        }
    }
}