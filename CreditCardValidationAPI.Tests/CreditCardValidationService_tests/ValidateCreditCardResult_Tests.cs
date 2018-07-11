using CreditCardValidationAPI.BLL.Domains;
using CreditCardValidationAPI.BLL.Services;
using Xunit;

namespace CreditCardValidationAPI.Tests.CreditCardValidationService_tests
{
    public class ValidateCreditCardResult_Tests
    {
        [Fact]
        public void When_Any_ExpiryDate_Is_Not_Number_Return_Invalid()
        {
            //Arrange
            CreditCardValidationService service = new CreditCardValidationService();
            string expiryDate = "132B18";

            //Act
            var result = service.ValidateCreditCardResult(expiryDate);

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
            CreditCardValidationService service = new CreditCardValidationService();
            string expiryDate = invalidExpiryDate;

            //Act
            var result = service.ValidateCreditCardResult(expiryDate);

            //Assert
            Assert.Equal(CardValidationResult.InValid, result);
        }
    }
}
