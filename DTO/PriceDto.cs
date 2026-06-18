using System.Text.Json.Serialization;

namespace CryptoMarketApi.DTO
{
    class PriceDto
    {
        [JsonPropertyName("brl")]
        public decimal Brl { get; set; }
    }
}