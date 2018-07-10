using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!expiryDate.IsAllCharactorNumber())
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
