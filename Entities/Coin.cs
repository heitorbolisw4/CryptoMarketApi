namespace CryptoMarketApi.Entities
{
    public class Coin
    {
        public int Id { get; set; }
        public string CoinName { get; set; } = string.Empty;
        public string CoinSymbol { get; set; } = string.Empty;
        public string CoinGeckoId { get; set; } = string.Empty;

        public List<Price>? Prices { get; set; }
    }
}