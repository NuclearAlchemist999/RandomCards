using RandomCards.Dto.DtoModels;
using RandomCards.Models;

namespace RandomCards.Dto.Converters
{
    public static class HandInfoConverter
    {
        public static HandInfoDto ToHandInfoDto(this Hand hand)
        {
            return new HandInfoDto
            {
                GameId = hand.GameId,
                HandId = hand.Id,
                Cards = hand.CardHands.Select(x => new CardDto
                {
                    CardId = x.CardId,
                    CardName = x.Card.Name,

                }).ToList(),
            };
        }

        public static List<HandInfoDto> ToHandInfoDtoList(this List<Hand> hands)
        {
            return hands.Select(x => x.ToHandInfoDto()).ToList();
        }

        public static ExtendHandInfoDto ToExtendHandInfoDto(this HandInfoDto dto, int count)
        {
            return new ExtendHandInfoDto
            {
                GameId = dto.GameId,
                HandId = dto.HandId,
                Cards = dto.Cards,
                GameCardCount = count
            };
        }
    }
}
