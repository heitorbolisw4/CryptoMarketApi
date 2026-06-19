namespace CryptoMarketApi.Interface
{
    interface ICoinGeckoService
    {
        public Task UpdatePricesAsync();
    }
}