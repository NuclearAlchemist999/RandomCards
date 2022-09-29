using RandomCards.Dto.Converters;
using RandomCards.Dto.DtoModels;
using RandomCards.Exceptions;
using RandomCards.Models;
using RandomCards.Repositories.CardRepository;
using RandomCards.Requests;

namespace RandomCards.Services.CardService
{
    /// <summary>
    /// Business logic are handled here. The public methods are InitializeGame, AddNewCardsInHand and GetHands.
    /// InitializeGame will handle the first five cards and the AddNewCardsInHand takes parameters of the incoming card ids
    /// and will replace the thrown cards with new cards. GetHands will get the history of the card hands and return a dto.
    /// </summary>
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

        private async Task<Hand> GetHand(Guid id)
        {
            var hand = await _cardRepo.GetHand(id);

            if (hand == null)
            {
                throw new HandNotFoundException(id);
            }

            return hand;
        }
        
        public async Task<HistoryResponseDto> GetHands()
        {
            var hands = await _cardRepo.GetHands();

            var handListDto = hands.ToHandInfoDtoList();

            return new HistoryResponseDto { HistoryItems = handListDto };
        }

        private async Task<int> GetCardsInGame(Guid id)
        {
            var cards = await _cardRepo.GetCardsByGameId(id);

            return cards.Count();
        }

        public async Task<ExtendHandInfoDto> InitializeGame()
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

            var numberOfCardsInGame = await GetCardsInGame(game.Id);

            return hand.ToHandInfoDto().ToExtendHandInfoDto(numberOfCardsInGame);
        }

        public async Task<ExtendHandInfoDto> AddNewCardsInHand(ThrowCardsRequest request, Guid gameId)
        {
            await ValidateNewHand(request, gameId);

            var hand = await AddHand(gameId);

            var previousCards = await _cardRepo.GetCardsInHandByHandId(request.PreviousHandId);

            foreach (var card in previousCards)
            {
                await AddCardsInHand(card.CardId, hand.Id);
            }

            foreach (var cardId in request.CardIds)
            {
                var randCard = await GetRandomCardInGame(gameId);

                var deleteCard = await _cardRepo.GetCardInHandByCardIdAndHandId(cardId, hand.Id);

                await _cardRepo.DeleteCardInHand(deleteCard);

                await AddCardsInHand(randCard.CardId, hand.Id);

                var deleteRandomCard = await _cardRepo.GetCardByGameIdAndCardId(gameId, randCard.CardId);

                await _cardRepo.DeleteCardInGame(deleteRandomCard);
            }

            var numberOfCardsInGame = await GetCardsInGame(gameId);

            var newHand = await GetHand(hand.Id);

            return newHand.ToHandInfoDto().ToExtendHandInfoDto(numberOfCardsInGame);
        }

        private async Task ValidateNewHand(ThrowCardsRequest request, Guid gameId)
        {
            var cardsInGame = await _cardRepo.GetCardsByGameId(gameId);

            if (cardsInGame.Count == 0)
            {
                throw new CardsInGameNotFoundException(gameId);
            }

            if (cardsInGame.Count < request.CardIds.Count)
            {
                throw new MoreThrownCardsThanGameCardsLeftBadRequestException();
            }

            if (request.CardIds.Count > 5 || request.CardIds.Count < 1)
            {
                throw new NumberOfCardsNotAllowedBadRequestException();
            }

            var hashset = new HashSet<Guid>();

            foreach (var cardId in request.CardIds)
            {
                if (!hashset.Add(cardId))
                {
                    throw new NoDuplicateIdsBadRequestException();
                }

                var card = await _cardRepo.GetCardInHandByCardIdAndHandId(cardId, request.PreviousHandId);

                if (card == null)
                {
                    throw new CardInHandNotFoundException(cardId, request.PreviousHandId);
                }
            }
        }
    }
}
