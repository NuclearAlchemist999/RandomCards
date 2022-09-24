using RandomCards.Dto.Converters;
using RandomCards.Dto.DtoModels;
using RandomCards.Models;
using RandomCards.Repositories.CardRepository;

namespace RandomCards.Services.CardService
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepo;

        public CardService(ICardRepository cardRepo)
        {
            _cardRepo = cardRepo;
        }
        private async Task<Hand> AddHand(Guid gameId)
        {
            var hand = new Hand { Id = Guid.NewGuid(), GameId = gameId };

            await _cardRepo.AddHand(hand);

            return hand;
        }
        private async Task<Game> AddGame()
        {
            var game = new Game { Id = Guid.NewGuid() };

            await _cardRepo.AddGame(game);

            return game;
        }
        private async Task<CardGame> AddCardsInGame(Guid cardId, Guid gameId)
        {
            var cardGame = new CardGame { Id = Guid.NewGuid(), CardId = cardId, GameId = gameId };

            await _cardRepo.AddCardToGame(cardGame);

            return cardGame;
        }
        private async Task<CardHand> AddCardsInHand(Guid cardId, Guid handId)
        {
            var handCard = new CardHand { Id = Guid.NewGuid(), CardId = cardId, HandId = handId };

            await _cardRepo.AddCardToHand(handCard);

            return handCard;
        }
        private async Task<CardGame> GetRandomCardInGame(Guid gameId)
        {
            var cardsInGame = await _cardRepo.GetCardsByGameId(gameId);

            var random = new Random();
            var randNumb = random.Next(cardsInGame.Count());
            var randCard = cardsInGame[randNumb];

            return randCard;
        }
        public async Task<HandInfoDto> GetHand(Guid id)
        {
            var hand = await _cardRepo.GetHand(id);

            if (hand == null)
            {
                throw new Exception();
            }

            return hand.ToHandInfoDto();
        }
        public async Task<List<HandInfoDto>> GetHands()
        {
            var hands = await _cardRepo.GetHands();

            return hands.ToHandInfoDtoList();
        }
        public async Task<HandInfoDto> InitializeGame()
        {
            var cards = await _cardRepo.GetCards();

            if (cards.Count == 0)
            {
                throw new Exception();
            }

            var game = await AddGame();

            foreach (var card in cards)
            {
                await AddCardsInGame(card.Id, game.Id);
            }

            var hand = await AddHand(game.Id);

            for (int i = 0; i < 5; i++)
            {
                var randCard = await GetRandomCardInGame(game.Id);

                await AddCardsInHand(randCard.CardId, hand.Id);

                var deleteCard = await _cardRepo.GetCardByGameIdAndCardId(game.Id, randCard.CardId);

                await _cardRepo.DeleteCardInGame(deleteCard);
            }

            return await GetHand(hand.Id);
        }
    }
}
