using CryptoMarketApi.Data;
using CryptoMarketApi.DTO;
using CryptoMarketApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoMarketApi.Service
{
    public class CoinGeckoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly AppDbContext _db;
        private readonly string _url;
        private readonly string _apikey;

        public CoinGeckoService(HttpClient httpClient, IConfiguration config, AppDbContext db)
        {
            _httpClient = httpClient;
            _config = config;
            _db = db;
            _url = config["CoinGecko:BaseUrl"]!;
            _apikey = config["CoinGecko:ApiKey"]!;
        }
        public async Task UpdatePricesAsync()
        {
            // i find the coins at the database
            var coins = await _db.Coins.ToListAsync();

            // busco ids das moedas no banco
            var ids = string.Join(",", coins.Select(c => c.CoinGeckoId));
            // monto a url
            var url = $"{_url}?vs_currencies=brl&ids={ids}&x_cg_demo_api_key={_apikey}";
            // ???
            var resultado = await _httpClient.GetFromJsonAsync<Dictionary<string, PriceDto>>(url);



        }
    }
}