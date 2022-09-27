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

            await SaveChanges();

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

        public async Task<CardGame> GetCardByGameIdAndCardId(Guid gameId, Guid cardId)
        {
            var card = await _cardDbContext.Cards_Games.FirstOrDefaultAsync(x => x.GameId == gameId
            && x.CardId == cardId);

            return card;
        }

        public async Task DeleteCardInGame(CardGame card)
        {
            _cardDbContext.Cards_Games.Remove(card);

            await SaveChanges();
        }

        public async Task<Hand> AddHand(Hand hand)
        {
            _cardDbContext.Hands.Add(hand);

            await SaveChanges();

            return hand;
        }

        public async Task<CardHand> AddCardToHand(CardHand card)
        {
            _cardDbContext.Cards_Hands.Add(card);

            await SaveChanges();

            return card;
        }

        public async Task<CardGame> AddCardToGame(CardGame card)
        {
            _cardDbContext.Cards_Games.Add(card);

            await SaveChanges();

            return card;
        }

        public async Task<List<CardHand>> GetCardsInHandByHandId(Guid id)
        {
            var cards = await _cardDbContext.Cards_Hands.Where(x => x.HandId == id).ToListAsync();

            return cards;
        }

        public async Task<CardHand> GetCardInHandByCardIdAndHandId(Guid cardId, Guid handId)
        {
            var card = await _cardDbContext.Cards_Hands.FirstOrDefaultAsync(x =>
                x.CardId == cardId && x.HandId == handId);

            return card;
        }

        public async Task DeleteCardInHand(CardHand card)
        {
            _cardDbContext.Cards_Hands.Remove(card);

            await SaveChanges();
        }

        public async Task<Hand> GetHand(Guid id)
        {
            var hand = await _cardDbContext.Hands.Include(x => x.CardHands).ThenInclude(x => x.Card)
                .FirstOrDefaultAsync(x => x.Id == id);

            return hand;
        }

        public async Task<List<Hand>> GetHands()
        {
            var hands = await _cardDbContext.Hands.Include(x => x.CardHands).ThenInclude(x => x.Card)
                .Include(x => x.Game)
                .OrderByDescending(x => x.Game.TimeStamp)
                .ThenByDescending(x => x.TimeStamp)
                .Take(40)
                .ToListAsync();

            return hands;
        }

        public async Task SaveChanges()
        {
            await _cardDbContext.SaveChangesAsync();
        }
    }
}
