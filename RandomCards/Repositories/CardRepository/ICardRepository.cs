using RandomCards.Models;

namespace RandomCards.Repositories.CardRepository
{
    public interface ICardRepository
    {
        Task<Game> AddGame(Game game);
        Task<List<Card>> GetCards();
        Task<List<CardGame>> GetCardsByGameId(Guid id);
    }
}
