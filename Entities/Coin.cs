namespace CryptoMarketApi.Entities
{
    class Coin
    {
        public int Id { get; set; }
        public string CoinName { get; set; } = string.Empty;
        public string CoinSymbol { get; set; } = string.Empty;
    }
}