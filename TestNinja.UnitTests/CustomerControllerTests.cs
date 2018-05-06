using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdEquals0_ShouldReturnNotFoundType()
        {
            var sut = new CustomerController();

            var result = sut.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdGreaterThan0_ShouldReturnOkType()
        {
            var sut = new CustomerController();

            var result = sut.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
