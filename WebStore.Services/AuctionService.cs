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
                    auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price, Seller = auction.Seller });
            }
            return auctionDtos;

        }
        public IEnumerable<AuctionDto> GetAllSold(UserDto user)
        {
            var auctionDtos = new List<AuctionDto>();
        
            foreach (Auction auction in _auctionRepository.GetAllSold())
            {
                if (auction.Status == "Sold" && auction.Seller == user.UserName)
                    auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price, Buyer=auction.Buyer});
            }
            return auctionDtos;

        }

        public IEnumerable<AuctionDto> GetAllBought(UserDto user)
        {
            var auctionDtos = new List<AuctionDto>();

            foreach (Auction auction in _auctionRepository.GetAllBought())
            {
                if (auction.Status == "Sold" && auction.Buyer == user.UserName)
                    auctionDtos.Add(new AuctionDto { Id = auction.Id, Name = auction.Name, Price = auction.Price, Seller = auction.Seller });
            }
            return auctionDtos;

        }
    }
}