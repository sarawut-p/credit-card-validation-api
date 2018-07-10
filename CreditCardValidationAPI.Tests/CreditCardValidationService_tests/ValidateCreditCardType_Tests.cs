using CreditCardValidationAPI.BLL.Domain;
using CreditCardValidationAPI.BLL.Services;
using System;
using Xunit;

namespace CreditCardValidationAPI.Tests
{
    public class ValidateCreditCardType_Tests
    {
        [Fact]
        public void When_Card_Number_Start_With_4_Return_CardType_As_Visa()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCardType("400000000000000");

            //Assert
            Assert.Equal(CardType.Visa, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_5_Return_CardType_As_MasterCard()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCardType("500000000000000");

            //Assert
            Assert.Equal(CardType.MasterCard, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_3_And_15_Digit_Long_Return_CardType_As_Amex()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCardType("300000000000000");

            //Assert
            Assert.Equal(CardType.Amex, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_3_And_16_Digit_Long_Return_CardType_As_JCB()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCardType("3000000000000000");

            //Assert
            Assert.Equal(CardType.JCB, result);
        }

        [Theory]
        [InlineData("100000000000000")]
        [InlineData("200000000000000")]
        [InlineData("600000000000000")]
        [InlineData("700000000000000")]
        [InlineData("800000000000000")]
        [InlineData("900000000000000")]
        [InlineData("000000000000000")]
        public void When_CreditCardNumber_Not_Match_Specification_Return_CardType_As_Unknown(string creditCardNumber)
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCardType(creditCardNumber);

            //Assert
            Assert.Equal(CardType.Unknown, result);
        }
    }
}
