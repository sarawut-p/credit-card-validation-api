using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CreditCardValidationAPI.BLL.Domain;
using CreditCardValidationAPI.BLL.Domains;
using CreditCardValidationAPI.DAL.Repositories;
using CreditCardValidationAPI.SharedKernal;

namespace CreditCardValidationAPI.BLL.Services
{
    public class CreditCardValidationService : ICreditCardValidationServices
    {
        private List<CardTypeRule> _cardTypeRules;
        private ICreditCardRepository _creditCardRepository;

        public CreditCardValidationService(ICreditCardRepository creditCardRepository)
        {
            List<int> primeNumberUpTo2099 = new List<int>()
            {
                2017, 2027, 2029, 2039, 2053, 2063, 2069, 2081, 2083, 2087, 2089, 2099
            };

            this._creditCardRepository = creditCardRepository;
            this._cardTypeRules = new List<CardTypeRule>()
            {
                new CardTypeRule(){ StartNumber = 4, CardType = CardType.Visa, IsValidCriteria = (int expiryYear) => DateTime.IsLeapYear(expiryYear) },
                new CardTypeRule(){ StartNumber = 5, CardType = CardType.MasterCard, IsValidCriteria = (int expiryYear)=>primeNumberUpTo2099.Contains(expiryYear)},
                new CardTypeRule(){ StartNumber = 3, CardType = CardType.JCB},
                new CardTypeRule(){ StartNumber = 3, CardType = CardType.Amex, Length = 15}
            };
        }

        public CardValidationResult ValidateCreditCardResult(string creditCardNumber, string expiryDate)
        {
            if (!this._creditCardRepository.IsExist(creditCardNumber))
            {
                return CardValidationResult.DoesNotExist;
            }

            var expiryDateRexEx = new Regex(@"(0[1-9]|10|11|12)20[0-9]{2}");
            if (!expiryDateRexEx.IsMatch(expiryDate))
            {
                return CardValidationResult.InValid;
            }
            
            var expiryYear = int.Parse(expiryDate.Substring(2, 4));
            var matchedRule = this._cardTypeRules.FirstOrDefault(rule => rule.IsMatch(creditCardNumber));
            
            return (matchedRule == null || !matchedRule.IsValid(expiryYear)) ? 
                   CardValidationResult.InValid : CardValidationResult.Valid;
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
