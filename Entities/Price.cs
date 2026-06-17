namespace CryptoMarketApi.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public int CoinId { get; set; }
        public Coin? Coin { get; set; }
        public decimal Value { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}