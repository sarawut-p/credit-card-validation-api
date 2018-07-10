using System;
using System.Collections.Generic;
using System.Text;
using CreditCardValidationAPI.BLL.Domain;

namespace CreditCardValidationAPI.BLL.Services
{
    public class CreditCardValidationService : ICreditCardValidationServices
    {
        public CardType ValidateCreditCard(string creditCardNumber)
        {
            return CardType.Visa;
        }
    }
}
