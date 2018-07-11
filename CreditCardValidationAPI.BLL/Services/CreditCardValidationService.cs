using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CreditCardValidationAPI.BLL.Domain;
using CreditCardValidationAPI.BLL.Domains;
using CreditCardValidationAPI.SharedKernal;

namespace CreditCardValidationAPI.BLL.Services
{
    public class CreditCardValidationService : ICreditCardValidationServices
    {
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

        public CardValidationResult ValidateCreditCardResult(string expiryDate)
        {
            var expiryDateRexEx = new Regex(@"(0[1-9]|10|11|12)20[0-9]{2}");
            if (!expiryDateRexEx.IsMatch(expiryDate))
            {
                return CardValidationResult.InValid;
            }

            throw new NotSupportedException();
        }

        public CardType ValidateCreditCardType(string creditCardNumber)
        {
            if (!creditCardNumber.IsAllCharactorNumber())
            {
                return CardType.Unknown;
            }

            var matchedRule = this._cardTypeRules.FirstOrDefault(rule => rule.IsMatch(creditCardNumber));
            return (matchedRule != null) ? matchedRule.CardType : CardType.Unknown;
        }
    }
}
