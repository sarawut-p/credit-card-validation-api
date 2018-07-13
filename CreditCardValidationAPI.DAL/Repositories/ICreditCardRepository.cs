using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidationAPI.DAL.Repositories
{
    public interface ICreditCardRepository
    {
        bool IsExist(string credit);
    }
}
