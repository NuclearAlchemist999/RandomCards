

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
    }
}
