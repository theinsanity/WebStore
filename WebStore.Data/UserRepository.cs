using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.Contracts.Models;
using WebStore.Data.Contracts.RepositoryInterface;

namespace WebStore.Data
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAllUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserName= "pera",
                    Password="123",
                    Email = "pera@peran.com",
                    Credit = 1000
                }
            };
        }
    }
}
