using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Services.Contracts.Dto;

namespace WebStore.Services.Contracts.ServiceInterface
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        bool CheckUserEmail(UserDto user); 
        bool CheckUserUsername(UserDto user);
        void CreateUser(UserDto user);
        bool LoginValidation(UserDto user);
        double GetUserCredit(UserDto user);
    }
}
