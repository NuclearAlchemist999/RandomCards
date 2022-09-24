using RandomCards.Dto.DtoModels;
using RandomCards.Requests;

namespace RandomCards.Services.CardService
{
    public interface ICardService
    {
        Task<HandInfoDto> InitializeGame();
        Task<HandInfoDto> AddNewCardsInHand(ThrowCardsRequest request, Guid gameId);
        Task<HandInfoDto> GetHand(Guid id);
        Task<List<HandInfoDto>> GetHands();
    }
}
