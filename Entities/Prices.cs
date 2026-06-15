namespace CryptoMarketApi.Entities
{
    class Prices
    {
        public int Id { get; set; }
        public int CoinId { get; set; }
        public decimal Value { get; set; }
        public DateTime RecirdedAt { get; set; }
    }
}