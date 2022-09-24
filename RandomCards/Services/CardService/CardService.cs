﻿using RandomCards.Models;
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
    }
}
