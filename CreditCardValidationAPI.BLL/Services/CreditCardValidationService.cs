using System.Collections.Generic;
using System.Linq;
using CreditCardValidationAPI.BLL.Domain;

namespace CreditCardValidationAPI.BLL.Services
{
    public class CreditCardValidationService : ICreditCardValidationServices
    {
        private class CardTypeRule
        {
            public const short DEFAULT_LENGTH = 16;
            public short StartNumber;
            public short Length = DEFAULT_LENGTH;
            public CardType CardType;
        }

        private List<CardTypeRule> _cardTypeRules;

        public CreditCardValidationService()
        {
            this._cardTypeRules = new List<CardTypeRule>()
            {
                new CardTypeRule(){ StartNumber = 4, CardType = CardType.Visa},
                new CardTypeRule(){ StartNumber = 5, CardType = CardType.MasterCard},
                new CardTypeRule(){ StartNumber = 3, CardType = CardType.JCB},
                new CardTypeRule(){ StartNumber = 3, CardType = CardType.Amex, Length = 15}
            };
        }

        public CardType ValidateCreditCardType(string creditCardNumber)
        {
            var matchedRule = this._cardTypeRules.FirstOrDefault(rule=> creditCardNumber.StartsWith(rule.StartNumber.ToString()) && 
                                                                        creditCardNumber.Length == rule.Length);

            return (matchedRule != null) ? matchedRule.CardType : CardType.Unknown;
        }
    }
}
