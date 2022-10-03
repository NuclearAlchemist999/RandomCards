using RandomCards.Models;

namespace RandomCards.Repositories.CardRepository
{
    /// <summary>
    /// Interface for the card repository.
    /// </summary>
    public interface ICardRepository
    {
        Task<Game> AddGame(Game game);
        Task<List<Card>> GetCards();
        Task<List<CardGame>> GetCardsByGameId(Guid id);
        Task<CardGame> GetCardByGameIdAndCardId(Guid gameId, Guid cardId);
        Task<Hand> AddHand(Hand hand);
        Task<List<CardHand>> GetCardsInHandByHandId(Guid id);
        Task<CardHand> GetCardInHandByCardIdAndHandId(Guid cardId, Guid handId);
        Task<List<CardHand>> GetCardsInHandByCardIdAndHandId(List<CardHand> cardsInHand);
        Task<Hand> GetHand(Guid id);
        Task<List<Hand>> GetHands();
        Task AddCardsInGame(List<CardGame> cardGames);
        Task AddCardsInHand(List<CardHand> cardHands);
        void DeleteCardInGame(CardGame cardInGame);
        void DeleteCardsInHand(List<CardHand> cardHands);
        Task SaveChanges();
    }
}
