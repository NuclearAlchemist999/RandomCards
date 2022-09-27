using RandomCards.Models;

namespace RandomCards.Tests.Repositories
{
    public class CardRepositoryTests
    {
        CardRepository cardRepo = new CardRepository();
        CardRepositoryMockData mockData = new CardRepositoryMockData();

        [Fact]
        public void AddGameAndGetThatGameTest()
        {
            // Arrange
            var newGame = mockData.NewGame();

            // Act
            cardRepo.AddGame(newGame);

            var game = cardRepo.SearchGame(newGame.Id);

            // Assert
            Assert.NotNull(game);
            Assert.Equal(newGame.Id, game.Id);
        }

        [Fact]
        public void AddAndGetCardsTest()
        {
            // Arrange 
            cardRepo.AddCards();

            //Act
            var cards = cardRepo.GetCards();

            // Assert
            Assert.Equal(52, cards.Count());
        }

        [Fact]
        public void AddCardToGameAndGetThatCardTest()
        {
            // Arrange
            var newCardGame = mockData.NewCardInGame();

            // Act
            cardRepo.AddCardToGame(newCardGame);
            var card = cardRepo.GetCardByGameIdAndCardId(newCardGame.GameId, newCardGame.CardId);

            // Assert
            Assert.Equal(newCardGame, card);
            Assert.NotNull(card);
        }

        [Fact]
        public void AddToHandAndGetThatHandTest()
        {
            // Arrange
            var newHand = mockData.NewHand();

            // Act
            cardRepo.AddHand(newHand);
            var hand = cardRepo.GetHand(newHand.Id);

            // Assert
            Assert.Equal(newHand, hand);
            Assert.NotNull(hand);
        }

        [Fact]
        public void AddCardToHandAndGetThatCardTest()
        {
            // Arrange
            var newCardHand = mockData.NewCardInHand();

            // Act
            cardRepo.AddCardToHand(newCardHand);
            var cardHand = cardRepo.GetCardInHandByCardIdAndHandId(newCardHand.CardId, newCardHand.HandId);

            // Assert

            Assert.Equal(newCardHand.Id, cardHand.Id);
            Assert.NotNull(cardHand);
        }

        [Fact]
        public void GetHandsTest()
        {
            // Arrange
            var newHands = cardRepo.hands;

            // Act
            for (int i = 0; i < 4; i++)
            {
                var newHand = mockData.NewHand();
                newHands.Add(newHand);
            }

            var hands = cardRepo.GetHands();

            // Assert
            Assert.Equal(4, hands.Count());

        }

        [Fact]
        public void GetCardsByGameIdTest()
        {
            // Arrange
            var cards = cardRepo.AddCards();
            var newCardGames = cardRepo.cardGames;
            var newGame = mockData.NewGame();

            // Act
            foreach (var card in cards)
            {
                newCardGames.Add(new CardGame { Id = Guid.NewGuid(), CardId = card.Id, GameId = newGame.Id });
            }

            var cardGames = cardRepo.GetCardsByGameId(newGame.Id);

            //Assert
            Assert.Equal(52, cardGames.Count());
        }
    }
}
