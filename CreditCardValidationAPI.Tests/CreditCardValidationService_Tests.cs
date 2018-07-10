using CreditCardValidationAPI.BLL.Domain;
using CreditCardValidationAPI.BLL.Services;
using System;
using Xunit;

namespace CreditCardValidationAPI.Tests
{
    public class CreditCardValidationService_Tests
    {
        [Fact]
        public void When_Card_Number_Start_With_4_Return_CardType_As_Visa()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCard("400000000000000");

            //Assert
            Assert.Equal(CardType.Visa, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_5_Return_CardType_As_MasterCard()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCard("500000000000000");

            //Assert
            Assert.Equal(CardType.MasterCard, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_3_And_15_Digit_Long_Return_CardType_As_Amex()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCard("300000000000000");

            //Assert
            Assert.Equal(CardType.Amex, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_3_And_16_Digit_Long_Return_CardType_As_JCB()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();

            //Act
            var result = service.ValidateCreditCard("3000000000000000");

            //Assert
            Assert.Equal(CardType.JCB, result);
        }
    }
}
