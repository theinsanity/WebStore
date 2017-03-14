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
        string CheckUser(UserDto _user);
    }
}
