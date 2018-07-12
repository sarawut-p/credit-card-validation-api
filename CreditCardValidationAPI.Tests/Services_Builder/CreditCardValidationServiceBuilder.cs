using CreditCardValidationAPI.BLL.Services;
using CreditCardValidationAPI.DAL.Repositories;
using Moq;

namespace CreditCardValidationAPI.Tests.Services_Builder
{
    public class CreditCardValidationServiceBuilder
    {
        public Mock<ICreditCardRepository> MockCreditCardRepository;
        public CreditCardValidationServiceBuilder()
        {
            this.MockCreditCardRepository = new Mock<ICreditCardRepository>();
            this.WhenCreditCardNumerIsExist();
        }

        public CreditCardValidationServiceBuilder WhenCreditCardNumerIsExist(bool isExist)
        {
            this.MockCreditCardRepository
                .Setup(x => x.IsExist(It.IsAny<string>()))
                .Returns(isExist);
            return this;
        }

        public CreditCardValidationServiceBuilder WhenCreditCardNumerIsExist()
        {
            this.WhenCreditCardNumerIsExist(true);
            return this;
        }

        public CreditCardValidationServiceBuilder WhenCreditCardNumerIsNotExist()
        {
            this.WhenCreditCardNumerIsExist(false);
            return this;
        }

        public CreditCardValidationService Build()
        {
            return new CreditCardValidationService(this.MockCreditCardRepository.Object);
        }
    }
}
