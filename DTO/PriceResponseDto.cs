namespace CryptoMarketApi.DTO
{
    public class PriceResponseDto
    {
        public string CoinName { get; set; } = string.Empty;
        public string CoinSymbol { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}