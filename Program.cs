using CryptoMarketApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

app.MapGet("/coins", (AppDbContext db) =>
{
    var coins = db.Coins.ToList();
    return Results.Ok(coins);
});

app.Run();
