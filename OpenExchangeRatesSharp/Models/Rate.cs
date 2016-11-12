namespace OpenExchangeRatesSharp.Models
{
    public class ConversionResult
    {
        public string Disclaimer { get; set; }
        public decimal License { get; set; }
        public Request Request { get; set; }
        public Meta Meta { get; set; }
        public decimal Response { get; set; }
    }
}