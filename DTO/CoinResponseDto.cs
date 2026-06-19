namespace CryptoMarketApi.DTO
{
    public class CoinResponseDto
    {
        public string CoinName { get; set; } = string.Empty;
        public string CoinSymbol { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}