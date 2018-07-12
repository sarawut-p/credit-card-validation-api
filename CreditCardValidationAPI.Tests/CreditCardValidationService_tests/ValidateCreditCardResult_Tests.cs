using CreditCardValidationAPI.BLL.Domains;
using CreditCardValidationAPI.BLL.Services;
using CreditCardValidationAPI.Tests.Services_Builder;
using System;
using Xunit;

namespace CreditCardValidationAPI.Tests.CreditCardValidationService_tests
{
    public class ValidateCreditCardResult_Tests
    {
        CreditCardValidationService service;
        CreditCardValidationServiceBuilder builder;

        public ValidateCreditCardResult_Tests()
        {
            builder = new CreditCardValidationServiceBuilder();
            service = builder.Build();
        }


        [Fact]
        public void When_Any_ExpiryDate_Is_Not_Number_Return_Invalid()
        {
            //Arrange
            string creditCardNumber = "3123456789123456";
            string expiryDate = "132B18";

            //Act
            var result = service.ValidateCreditCardResult(creditCardNumber,expiryDate);

            //Assert
            Assert.Equal(CardValidationResult.InValid, result);
        }

        [Theory]
        [InlineData("130000")]
        [InlineData("001987")]
        [InlineData("995789")]
        public void When_Expiry_Date_In_Invalid_Format_Return_Invalid(string invalidExpiryDate)
        {
            //Arrange
            string creditCardNumber = "3123456789123456";
            string expiryDate = invalidExpiryDate;

            //Act
            var result = service.ValidateCreditCardResult(creditCardNumber,expiryDate);

            //Assert
            Assert.Equal(CardValidationResult.InValid, result);
        }

        [Fact]
        public void When_CreditCard_Number_Does_Not_Exist_In_Database_Return_Does_Not_Exist()
        {
            //Arrange
            string creditCardNumber = "3123456789123456";
            string expiryDate = "1802539";

            service = builder.WhenCreditCardNumerIsNotExist()
                             .Build();

            //Act
            var result = service.ValidateCreditCardResult(creditCardNumber, expiryDate);

            //Assert
            Assert.Equal(CardValidationResult.DoesNotExist, result);
        }
    }
}
