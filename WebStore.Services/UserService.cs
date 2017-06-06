using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data.Contracts.Models;
using WebStore.Data.Contracts.RepositoryInterface;
using WebStore.Services.Contracts.Dto;
using WebStore.Services.Contracts.ServiceInterface;
namespace WebStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBCryptHashService _bcryptHashService;
        public UserService(IUserRepository userRepository, IBCryptHashService bcryptHashService)
        {
            _userRepository = userRepository;
            _bcryptHashService = bcryptHashService;
        }
        public IEnumerable<UserDto> GetAllUsers()
        {
            var userDtos = new List<UserDto>();
            foreach (User user in _userRepository.GetAllUsers())
            {
                userDtos.Add(new UserDto { UserName = user.UserName, Email = user.Email, Password = user.Password, Credit = user.Credit });
            }

            return userDtos;


        }
        public bool CheckUserEmail(UserDto user)
        {
                User usr = new User();
                usr.UserName = user.UserName;
                usr.Email = user.Email;
                usr.Password = user.Password;
                usr.Credit = user.Credit;

                bool var = _userRepository.CheckUserEmail(usr);
                return var;
        }
        
       public bool CheckUserUsername(UserDto user)
        {
            User usr = new User();
            usr.UserName = user.UserName;
            usr.Email = user.Email;
            usr.Password = user.Password;
            usr.Credit = user.Credit;

            bool var = _userRepository.CheckUserUsername(usr);
            return var;
           
        }
        public void CreateUser(UserDto user)
        {
            User usr = new User();
            usr.UserName = user.UserName;
            usr.Email = user.Email;
            usr.Password = _bcryptHashService.GetHashedValue(user.Password);
            usr.Credit = user.Credit;
            _userRepository.CreateUser(usr);
        }
        public bool LoginValidation(UserDto user)
        {
            var usr = new User();
            usr.UserName = user.UserName;            
            var usr1 = new User();
            usr1 = _userRepository.GetUser(usr);
            return _bcryptHashService.IsPasswordsEqual(user.Password, usr1.Password);

        }
        public double GetUserCredit(UserDto user)
        {
            var usr = new User();
            usr.UserName = user.UserName;
            return _userRepository.GetUserCredit(usr);
        }
        public void UpdateUser(UserDto user,AuctionDto auction)
        {
            var usr = new User();
            usr.UserName = user.UserName; 
            var usr1 = new User();
            usr1.UserName = auction.Seller.UserName;
            var credit = _userRepository.GetUserCredit(usr1);
            var usr2 = new User();
            usr2.UserName = auction.Seller.UserName;
            if (user.Credit - auction.Price >= 0)
            {
                usr.Credit = user.Credit - auction.Price;
                usr2.Credit = credit + auction.Price; 

            }
            else
            {
                return;
            }
            _userRepository.UpdateUser(usr, usr2);
        }
    }
}
