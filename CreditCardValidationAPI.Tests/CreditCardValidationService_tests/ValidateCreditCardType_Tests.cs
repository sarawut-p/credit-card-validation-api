using CreditCardValidationAPI.BLL.Domain;
using CreditCardValidationAPI.BLL.Services;
using CreditCardValidationAPI.Tests.Services_Builder;
using System;
using Xunit;

namespace CreditCardValidationAPI.Tests
{
    public class ValidateCreditCardType_Tests
    {
        CreditCardValidationService service;

        public ValidateCreditCardType_Tests()
        {
            service = new CreditCardValidationServiceBuilder().Build();
        }

        [Fact]
        public void When_Card_Number_Start_With_4_And_Length_16_Return_CardType_As_Visa()
        {
            //Act
            var result = service.ValidateCreditCardType("4000000000000000");

            //Assert
            Assert.Equal(CardType.Visa, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_5_And_Length_16_Return_CardType_As_MasterCard()
        {
            //Act
            var result = service.ValidateCreditCardType("5000000000000000");

            //Assert
            Assert.Equal(CardType.MasterCard, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_3_And_15_Digit_Long_Return_CardType_As_Amex()
        {
            //Act
            var result = service.ValidateCreditCardType("300000000000000");

            //Assert
            Assert.Equal(CardType.Amex, result);
        }

        [Fact]
        public void When_Card_Number_Start_With_3_And_16_Digit_Long_Return_CardType_As_JCB()
        {
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
            //Act
            var result = service.ValidateCreditCardType(creditCardNumber);

            //Assert
            Assert.Equal(CardType.Unknown, result);
        }

        [Theory]
        [InlineData("400")]
        [InlineData("500")]
        public void When_CreditCardNumber_Start_With_4_And_5_Length_Is_Not_16_Return_Unknow(string creditCardNumber)
        {
            //Act
            var result = service.ValidateCreditCardType(creditCardNumber);

            //Assert
            Assert.Equal(CardType.Unknown, result);
        }

        [Theory]
        [InlineData("500000000000000A")]
        [InlineData("40000B0000000000")]
        public void When_AnyChacter_Is_Not_Numberic_Return_Unknown(string creditCardNumber)
        {
            //Act
            var result = service.ValidateCreditCardType(creditCardNumber);

            //Assert
            Assert.Equal(CardType.Unknown, result);
        }
    }
}
