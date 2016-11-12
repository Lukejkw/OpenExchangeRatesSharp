using NUnit.Framework;
using OpenExchangeRatesSharp;

namespace UnitTests
{
    [TestFixture]
    public class RateClientTests
    {
        [Test]
        public void Ctor_WithApiKey_CanCreateClient()
        {
            Assert.DoesNotThrow(() => new RateClient("key"));
        }

        [Test]
        public void Ctor_WithApiKey_SetsApiKey()
        {
            var sut = new RateClient("key");
            Assert.AreEqual("key", sut.ApiKey);
        }
    }
}