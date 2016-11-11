using NUnit.Framework;
using OpenExchangeRatesSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    [TestFixture]
    public class RateClientTests
    {
        private string ApiKey => ConfigurationManager.AppSettings["api.key"];
        private string BaseCountry => ConfigurationManager.AppSettings["base.country.key"];

        [Test]
        public void GetLatestForFreePlan_WithValidApiKey_ReturnsRates()
        {
            var sut = new RateClient(ApiKey);

            var result = sut.GetLatest();

            Assert.NotNull(result);
            Assert.IsTrue(result.Rates.Any());
        }

        [Test]
        public void GetLatestForFreePlan_WithInvalidApiKey_ThrowsException()
        {
            var sut = new RateClient("invalid");

            var ex = Assert.Throws<Exception>(() => sut.GetLatest());
            Assert.IsTrue(ex.Message.Contains("Invalid API key"));
        }
    }
}