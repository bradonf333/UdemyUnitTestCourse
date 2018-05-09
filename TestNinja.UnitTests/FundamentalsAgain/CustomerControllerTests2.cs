using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests.FundamentalsAgain
{
    [TestFixture]
    [Category("FundamentalsAgain")]
    public class CustomerControllerTests2
    {
        [Test]
        public void GetCustomer_WhenIdEquals0_ShouldReturnTypeOfNotFound()
        {
            var sut = new CustomerController();

            var result = sut.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_WhenIdIsNot0_ShouldReturnTypeOfOk()
        {
            var sut = new CustomerController();

            var result = sut.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }

        [Test]
        public void GetCustomer_WhenIdIsAnyNumber_ShouldReturnInstanceOfActionResult()
        {
            var sut = new CustomerController();

            var result = sut.GetCustomer(0);

            Assert.That(result, Is.InstanceOf<ActionResult>());
        }
    }
}
