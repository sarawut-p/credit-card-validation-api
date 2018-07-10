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
            if (creditCardNumber.StartsWith("4"))
            {
                return CardType.Visa;
            }
            if (creditCardNumber.StartsWith("5"))
            {
                return CardType.MasterCard;
            }
            if (creditCardNumber.StartsWith("3") && creditCardNumber.Length == 15)
            {
                return CardType.Amex;
            }
            return CardType.JCB;
        }
    }
}
