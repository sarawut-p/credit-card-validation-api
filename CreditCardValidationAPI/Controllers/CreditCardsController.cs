using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CreditCardValidationAPI.BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditCardValidationAPI.Controllers
{

    public class CreditCardsController : Controller
    {
        CreditCardValidationService _creditCardValidationService;

        public CreditCardsController(CreditCardValidationService creditCardValidationService)
        {
            this._creditCardValidationService = creditCardValidationService;
        }

        // GET api/values
        [Route("api/creditcards/")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/creditcards/{creditCardNumber}/{expiryDate}")]
        public object Get(string creditCardNumber,string expiryDate)
        {
            return new { creditCardType = this._creditCardValidationService.ValidateCreditCardType(creditCardNumber),
                         isValid = this._creditCardValidationService.ValidateCreditCardResult(creditCardNumber,expiryDate)
            };
        }
    }
}
