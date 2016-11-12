using OpenExchangeRatesSharp.Models;

namespace OpenExchangeRatesSharp.Contracts
{
    public interface IRateClient
    {
        RateResult GetLatest(string baseCurrencyCode = "", string[] symbols = null);

        ConversionResult Convert(string fromCurrency, string toCurrency, decimal value);
    }
}