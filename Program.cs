using CryptoMarketApi.Data;
using CryptoMarketApi.DTO;
using CryptoMarketApi.Interface;
using CryptoMarketApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddHttpClient<CoinGeckoService>();
builder.Services.AddScoped<ICoinGeckoService, CoinGeckoService>();


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

app.MapGet("/prices", async (AppDbContext db, ICoinGeckoService service) =>
{
    await service.UpdatePricesAsync();

    var coins = db.Prices.Include( p=> p.Coin).Select(p => new PriceResponseDto
    {
        CoinName = p.Coin!.CoinName,
        CoinSymbol = p.Coin!.CoinSymbol,
        Value = p.Value,
        RecordedAt = p.RecordedAt
    }).ToListAsync();
    
    return Results.Ok(coins);
});
app.MapGet("/coins", async (AppDbContext db, ICoinGeckoService service) =>
{
    
});
app.Run();
