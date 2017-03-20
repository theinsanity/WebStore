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
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            usr.Password = user.Password;
            usr.Credit = user.Credit;
            _userRepository.CreateUser(usr);
        }
        public bool LoginValidation(UserDto user)
        {
            var usr = new User();
            usr.UserName = user.UserName;
            usr.Password = user.Password;
            return _userRepository.LoginValidation(usr);
        }
        public double GetUserCredit(UserDto user)
        {
            var usr = new User();
            usr.UserName = user.UserName;
            return _userRepository.GetUserCredit(usr);
        }

    }
}
