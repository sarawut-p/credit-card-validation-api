using System;
using System.Collections.Generic;
using System.Text;
using CreditCardValidationAPI.BLL.Domain;

namespace CreditCardValidationAPI.BLL.Services
{
    public class CreditCardValidationService : ICreditCardValidationServices
    {       
        public CardType ValidateCreditCardType(string creditCardNumber)
        {
            if (creditCardNumber.StartsWith("4") && creditCardNumber.Length == 16)
            {
                return CardType.Visa;
            }
            if (creditCardNumber.StartsWith("5") && creditCardNumber.Length == 16)
            {
                return CardType.MasterCard;
            }
            if (creditCardNumber.StartsWith("3"))
            {
                if(creditCardNumber.Length == 15) {
                    return CardType.Amex;
                }
                if (creditCardNumber.Length == 16)
                {
                    return CardType.JCB;
                }
            }
            return CardType.Unknown;
        }
    }
}
