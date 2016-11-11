using OpenExchangeRatesSharp.Contracts;
using OpenExchangeRatesSharp.Models;
using RestSharp;
using System;
using System.Net;

namespace OpenExchangeRatesSharp
{
    public class RateClient : IRateClient
    {
        private const string DefaultBaseUrl = "https://openexchangerates.org/api/";
        public const string DefaultBaseCurrency = "USD";
        private readonly RestClient _restClient;

        public string ApiKey { get; set; }

        public RateClient(string apiKey)
        {
            ApiKey = apiKey;
            _restClient = new RestClient(DefaultBaseUrl);
        }

        public RateClient(string apiKey, string baseUrl)
        {
            ApiKey = apiKey;
            _restClient = new RestClient(baseUrl);
        }

        /// <summary>
        /// Gets all the latest exchange rates. If you are on the free plan only use the defaults.
        /// </summary>
        /// <param name="baseCurrencyCode">The currency to use was the base</param>
        /// <param name="symbols">The currencies to show rates for (default is all)</param>
        /// <returns></returns>
        public RateResult GetLatest(string baseCurrencyCode = DefaultBaseCurrency, string[] symbols = null)
        {
            var request = new RestRequest("latest.json", Method.GET);
            request.AddQueryParameter("app_id", ApiKey);

            if (baseCurrencyCode != DefaultBaseCurrency)
                request.AddQueryParameter("base", baseCurrencyCode);
            if (symbols != null)
                request.AddQueryParameter("symbols", string.Join(",", symbols));
            return Execute<RateResult>(request);
        }

        private T Execute<T>(RestRequest request)
            where T : new()
        {
            var response = _restClient.Execute<T>(request);
            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                if (response != null &&
                    (response.StatusCode == HttpStatusCode.Forbidden
                    || response.StatusCode == HttpStatusCode.Unauthorized))
                {
                    throw new Exception("Invalid API key");
                }
                throw new Exception("Could not get rates from endpoint");
            }
            return response.Data;
        }
    }
}