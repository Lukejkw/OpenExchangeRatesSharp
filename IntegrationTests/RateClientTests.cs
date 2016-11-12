using NUnit.Framework;
using OpenExchangeRatesSharp;
using System;
using System.Configuration;
using System.Linq;

namespace IntegrationTests
{
    [TestFixture]
    public class RateClientTests
    {
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

        #region Helpers

        private bool IsInAppVeyor
        {
            get
            {
                string value = Environment.GetEnvironmentVariable("APPVEYOR");
                if (string.IsNullOrEmpty(value))
                    return false;
                return Convert.ToBoolean(value);
            }
        }

        private string ApiKey
        {
            get
            {
                if (IsInAppVeyor)
                {
                    return Environment.GetEnvironmentVariable("api.key");
                }
                return ConfigurationManager.AppSettings["api.key"];
            }
        }

        #endregion
    }
}