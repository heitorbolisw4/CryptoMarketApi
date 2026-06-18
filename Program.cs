using CryptoMarketApi.Data;
using CryptoMarketApi.DTO;
using CryptoMarketApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

app.MapGet("/coins", async (AppDbContext db, CoinGeckoService service) =>
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

app.Run();
