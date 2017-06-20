using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Services.Contracts.Dto;

namespace WebStore.Services.Contracts.ServiceInterface
{
    public interface IAuctionService
    {
        IEnumerable<AuctionDto> GetAllAuctions();
        void CreateAuction(AuctionDto auction);
        void UpdateAuction(AuctionDto auction);
        void DeleteAuction(AuctionDto auction);
        IEnumerable<AuctionDto> GetAllSold(AuctionDto act);
        IEnumerable<AuctionDto> GetAllBought(AuctionDto act);
        AuctionDto FindAuction(int id);
        IEnumerable<AuctionDto> GetAllUsersAuctions(AuctionDto act);
    }
    
}
