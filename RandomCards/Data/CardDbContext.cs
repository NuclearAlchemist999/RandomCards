using Microsoft.EntityFrameworkCore;
using RandomCards.Configuration;
using RandomCards.Models;

namespace RandomCards.Data
{
    /// <summary>
    /// The database tables based on the models.
    /// </summary>
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfiguration());
        }
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<CardGame> Cards_Games => Set<CardGame>();
        public DbSet<Hand> Hands => Set<Hand>();
        public DbSet<CardHand> Cards_Hands => Set<CardHand>();
    }
}
