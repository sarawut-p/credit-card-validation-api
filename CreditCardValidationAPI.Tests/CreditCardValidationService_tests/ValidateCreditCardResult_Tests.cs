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

        //[Fact]
        //public void When_ValidateResult_Month_Is_In_Incorrect_Format_Return_Invalid()
        //{
        //    //Arrange
        //    CreditCardValidationService service = new CreditCardValidationService();
        //    string expiryDate = "132018";

        //    //Act
        //    var result = service.ValidateCreditCardResult(expiryDate);

        //    //Assert
        //    Assert.Equal(CardType.Unknown, result);
        //}
    }
}
