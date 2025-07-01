using OpenExchangeRatesSharp.Contracts;
using OpenExchangeRatesSharp.Models;
using RestSharp;
using System;
using System.Net;

namespace OpenExchangeRatesSharp
{
    public class RateClient : IRateClient
    {
        #region Members & Ctors

        private const string DefaultBaseUrl = "https://openexchangerates.org/api/";
        public const string DefaultBaseCurrency = "USD";
        private readonly RestClient _restClient;

        /// <summary>
        /// The API KEY that is used for requests
        /// </summary>
        public string ApiKey { get; set; }

        public RateClient(string apiKey)
        {
            ApiKey = apiKey;
            _restClient = new RestClient(DefaultBaseUrl);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all the latest exchange rates. (If you are on the free plan only use the defaults.)
        /// </summary>
        /// <param name="baseCurrencyCode">The currency to use was the base</param>
        /// <param name="symbols">The currencies to show rates for (default is all)</param>
        /// <returns></returns>
        public RateResult GetLatest(string baseCurrencyCode = DefaultBaseCurrency, string[] symbols = null)
        {
            var request = new RestRequest("latest.json", Method.Get);
            if (baseCurrencyCode != DefaultBaseCurrency)
                request.AddQueryParameter("base", baseCurrencyCode);
            if (symbols != null)
                request.AddQueryParameter("symbols", string.Join(",", symbols));
            return Execute<RateResult>(request);
        }

        /// <summary>
        /// Converts from one currency to another (ONLY AVAILABLE TO UNLIMITED PLAN MEMBERS)
        /// </summary>
        /// <param name="fromCurrency"></param>
        /// <param name="toCurrency"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ConversionResult Convert(string fromCurrency, string toCurrency, decimal value)
        {
            var request = new RestRequest($"convert/{value}/{fromCurrency}/{toCurrency}", Method.Get);
            return Execute<ConversionResult>(request);
        }

        #endregion

        private T Execute<T>(RestRequest request) where T : new()
        {
            request.AddQueryParameter("app_id", ApiKey);

            var response = _restClient.Execute<T>(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }

            if (response != null && (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized))
            {
                throw new Exception("Invalid API key or you are not permitted to call this method");
            }
            throw new Exception("Could not get response for one or more reasons");
        }
    }
}