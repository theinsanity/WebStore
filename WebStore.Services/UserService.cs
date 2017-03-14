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
        public string CheckUser(UserDto _user)
        {

            var userDtos = new List<UserDto>();
            foreach (User user in _userRepository.GetAllUsers())
            {
                if (_user.Email == user.Email)
                {
                    return "Email already exists!";
                }
                if (_user.UserName == user.UserName)
                {
                    return "Username already exists!";
                }
            }
            return "Success";
        }



    }
}
