using DevOne.Security.Cryptography.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Services.Contracts.ServiceInterface;

namespace WebStore.Services
{
    public class BCryptHashService : IBCryptHashService
    {




        public string GetHashedValue(string plainText)
        {
            return BCryptHelper.HashPassword(plainText, BCryptHelper.GenerateSalt());
        }
        public bool IsPasswordsEqual(string plainText, string hashedValue)
        {
            return BCryptHelper.CheckPassword(plainText, hashedValue);
        }




    }
}
