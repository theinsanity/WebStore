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
        IEnumerable<AuctionDto> GetAllSold(UserDto user);
        IEnumerable<AuctionDto> GetAllBought(UserDto user);
    }
    
}
