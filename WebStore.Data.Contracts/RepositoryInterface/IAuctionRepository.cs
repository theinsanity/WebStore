using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.Contracts.Models;

namespace WebStore.Data.Contracts.RepositoryInterface
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> GetAllAuctions();
        void CreateAuction(Auction auction);
        void UpdateAuction(Auction auction);
        void DeleteAuction(Auction auction);
        IEnumerable<Auction> GetAllSold(Auction auction);
        IEnumerable<Auction> GetAllBought(Auction auction);
        IEnumerable<Auction> GetAllUsersAuctions(Auction auction);
        Auction FindAuction(int id);

    }
}
