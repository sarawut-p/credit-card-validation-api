using CreditCardValidationAPI.BLL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidationAPI.BLL.Services
{
    interface ICreditCardValidationServices
    {
        CardType ValidateCreditCard(string creditCardNumber);
    }
}
