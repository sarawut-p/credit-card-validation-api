using CreditCardValidationAPI.BLL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidationAPI.BLL.Domains
{
    public class CardTypeRule
    {
        public const short DEFAULT_LENGTH = 16;
        public short StartNumber;
        public short Length;
        public CardType CardType;

        public CardTypeRule()
        {
            this.Length = DEFAULT_LENGTH;
        }

        public bool IsMatch(string creditCardNumber)
        {
            return creditCardNumber.StartsWith(this.StartNumber.ToString()) &&
                   creditCardNumber.Length == this.Length;
        }
    }
}
