using RandomCards.Dto.DtoModels;
using RandomCards.Requests;

namespace RandomCards.Services.CardService
{
    /// <summary>
    /// Interface for the card service.
    /// </summary>
    public interface ICardService
    {
        Task<ExtendHandInfoDto> InitializeGame();
        Task<ExtendHandInfoDto> AddNewCardsInHand(ThrowCardsRequest request, Guid gameId);
        Task<HistoryResponseDto> GetHands();
    }
}
