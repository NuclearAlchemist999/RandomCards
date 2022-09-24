using Microsoft.EntityFrameworkCore;
using RandomCards.Data;
using RandomCards.Models;

namespace RandomCards.Repositories.CardRepository
{
    public class CardRepository : ICardRepository
    {
        private readonly CardDbContext _cardDbContext;

        public CardRepository(CardDbContext cardDbContext)
        {
            _cardDbContext = cardDbContext;
        }

        public async Task<Game> AddGame(Game game)
        {
            _cardDbContext.Games.Add(game);

            await _cardDbContext.SaveChangesAsync();

            return game;
        }

        public async Task<List<Card>> GetCards()
        {
            var cards = await _cardDbContext.Cards.ToListAsync();

            return cards;
        }

        public async Task<List<CardGame>> GetCardsByGameId(Guid id)
        {
            var cards = await _cardDbContext.Cards_Games.Where(x => x.GameId == id).ToListAsync();

            return cards;
        }
    }
}
