using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RandomCards.Models;

namespace RandomCards.Configuration
{
    /// <summary>
    /// Will run with migration and create cards in the database.
    /// </summary>
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        List<string> suits = new List<string> { "spades", "diamonds", "clubs", "hearts" };
        List<string> values = new List<string> { "ace", "two", "three", "four", "five", "six",
        "seven", "eight", "nine", "ten", "jack", "queen", "king" };
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    builder.HasData
                    (
                        new Card
                        {
                            Id = Guid.NewGuid(),
                            Name = value + " " + suit
                        }
                    );
                }
            }
        }
    }
}
