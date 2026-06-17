using CryptoMarketApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoMarketApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Coin> Coins { get; set; }

        DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coin>(entity =>
            {
               // definir id como pk
               entity.HasKey(c => c.Id);

               entity.Property(c => c.CoinName).HasMaxLength(100);

               entity.Property(c => c.CoinSymbol).HasMaxLength(20);
               entity.HasData(
                    new Coin{Id = 1, CoinGeckoId="bitcoin",CoinSymbol="BTC",CoinName="Bitcoin"},
                    new Coin{Id = 2, CoinGeckoId="monero",CoinSymbol="MON",CoinName="Monero"},
                    new Coin{Id = 3, CoinGeckoId="ethereum",CoinSymbol="ETH",CoinName="Ethereum"},
                    new Coin{Id = 4, CoinGeckoId="solana",CoinSymbol="SOL",CoinName="Solana"}
                );
                
            });
            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasOne(c => c.Coin).WithMany(c => c.Prices).HasForeignKey(c => c.CoinId);
            });
        }
    
    
    }
}