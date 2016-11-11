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

        public void Ctor_WithApiKeyAndBaseUrl_CanCreateClient()
        {
            Assert.DoesNotThrow(() => new RateClient("key", "http://fake.com"));
        }

        [Test]
        public void Ctor_WithApiKeyAndBaseUrl_SetsApiKey()
        {
            var sut = new RateClient("key", "http://fake.com");
            Assert.AreEqual("key", sut.ApiKey);
        }
    }
}