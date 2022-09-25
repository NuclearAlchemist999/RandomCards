using RandomCards.Dto.DtoModels;
using RandomCards.Requests;

namespace RandomCards.Services.CardService
{
    public interface ICardService
    {
        Task<HandInfoDto> InitializeGame();
        Task<ExtendHandInfoDto> AddNewCardsInHand(ThrowCardsRequest request, Guid gameId);
        Task<List<HandInfoDto>> GetHands();
    }
}
