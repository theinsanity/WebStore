using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Services.Contracts.ServiceInterface
{
    public interface IBCryptHashService
    {
        string GetHashedValue(string plainText);
        bool IsPasswordsEqual(string plainText, string hashedValue);
    }
}
