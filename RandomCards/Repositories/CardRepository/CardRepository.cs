using Microsoft.EntityFrameworkCore;
using RandomCards.Data;
using RandomCards.Models;
using RandomCards.Services.CardService;

namespace RandomCards.Repositories.CardRepository
{
    /// <summary>
    /// Closest methods to the database. The name of each method speaks for itself.
    /// </summary>
    public class CardRepository : ICardRepository
    {
        private readonly CardDbContext _cardDbContext;

        public CardRepository(CardDbContext cardDbContext)
        {
            _cardDbContext = cardDbContext;
        }

        public async Task<Game> AddGame(Game game)
        {
            await _cardDbContext.Games.AddAsync(game);
            return game;
        }

        public async Task<List<Card>> GetCards()
        {
            return await _cardDbContext.Cards.ToListAsync();
        }

        public async Task<List<CardGame>> GetCardsByGameId(Guid id)
        {
            return await _cardDbContext.Cards_Games.Where(x => x.GameId == id).ToListAsync();
        }

        public async Task<CardGame> GetCardByGameIdAndCardId(Guid gameId, Guid cardId)
        {
            return await _cardDbContext.Cards_Games.FirstOrDefaultAsync(x => x.GameId == gameId
            && x.CardId == cardId);
        }

        public async Task<Hand> AddHand(Hand hand)
        {
            await _cardDbContext.Hands.AddAsync(hand);
            return hand;
        }
        public async Task<List<CardHand>> GetCardsInHandByHandId(Guid id)
        {
            return await _cardDbContext.Cards_Hands.Where(x => x.HandId == id).ToListAsync();
        }

        public async Task<CardHand> GetCardInHandByCardIdAndHandId(Guid cardId, Guid handId)
        {
            return await _cardDbContext.Cards_Hands.FirstOrDefaultAsync(x =>
                x.CardId == cardId && x.HandId == handId);
        }

        public async Task<List<CardHand>> GetCardsInHandByCardIdAndHandId(List<CardHand> cardsInHand)
        {
            var cards = await _cardDbContext.Cards_Hands.ToListAsync();

            return cards.Where(ch => cardsInHand.Any(x => x.CardId == ch.CardId && x.HandId == ch.HandId)).ToList();
        }

        public async Task<Hand> GetHand(Guid id)
        {
            return await _cardDbContext.Hands.Include(x => x.CardHands).ThenInclude(x => x.Card)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Hand>> GetHands()
        {
            return await _cardDbContext.Hands.Include(x => x.CardHands).ThenInclude(x => x.Card)
                .Include(x => x.Game)
                .OrderByDescending(x => x.Game.TimeStamp)
                .ThenByDescending(x => x.TimeStamp)
                .Take(120)
                .ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _cardDbContext.SaveChangesAsync();
        }

        public async Task AddCardsInGame(List<CardGame> cardGames)
        {
            await _cardDbContext.Cards_Games.AddRangeAsync(cardGames);
        }

        public async Task AddCardsInHand(List<CardHand> cardHands)
        {
            await _cardDbContext.Cards_Hands.AddRangeAsync(cardHands);
        }

        public void DeleteCardInGame(CardGame cardInGame)
        {
            _cardDbContext.Cards_Games.Remove(cardInGame);
        }

        public void DeleteCardsInHand(List<CardHand> cardHands)
        {
            _cardDbContext.Cards_Hands.RemoveRange(cardHands);
        }
    }
}
