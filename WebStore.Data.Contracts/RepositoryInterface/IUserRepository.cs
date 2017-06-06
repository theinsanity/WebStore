using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.Contracts.Models;

namespace WebStore.Data.Contracts.RepositoryInterface
{
    public interface IUserRepository
    {
         
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(User user, User user1);
        User GetUser(User user);

        bool CheckUserEmail(User user);
        bool CheckUserUsername(User user); 
        double GetUserCredit(User user);
        
        
    }
}
