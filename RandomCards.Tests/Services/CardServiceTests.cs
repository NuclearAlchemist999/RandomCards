using RandomCards.Exceptions;
using RandomCards.Models;

namespace RandomCards.Tests.Services
{
    public class CardServiceTests
    {
        CardService cardService = new CardService();
        CardsInHandService cardsInHandService = new CardsInHandService();

        [Fact]

        public void InitializeGameTest()
        {
            // Arrange
            var game = cardService.InitializeGame();

            // Act
            var cardGame = cardService.GetCardsByGameId(game.Id);
            var hands = cardService.GetHandsByGameId(game.Id);

            // Assert

            Assert.NotNull(game);
            Assert.Equal(47, cardGame.Count());
            Assert.Equal(1, hands.Count());

            foreach (var hand in hands)
            {
                var cardInHand = cardService.GetCardsInHandByHandId(hand.Id);
                Assert.Equal(5, cardInHand.Count());
            }
        }

        [Fact]

        public void AddCardsInNewHandTest()
        {
            // Testing with strings instead of objects since card id guids are generated randomly for every test and the incoming
            // cards to be thrown away need to be hardcoded in testing
            // Arrange
            var cardsToThrow = new List<string> { "two diamonds", "king clubs" };

            // Act 
            var newHand = cardsInHandService.AddCardsInNewhand(cardsToThrow);
            var game = cardsInHandService.games;

            // Assert
            Assert.Equal(5, newHand.Count);
            Assert.Contains("ace spades", newHand);
            Assert.Contains("ace hearts", newHand);
            Assert.Contains("three hearts", newHand);
            Assert.DoesNotContain("two diamonds", newHand);
            Assert.DoesNotContain("king clubs", newHand);
            Assert.Equal(45, game.Count);
            Assert.DoesNotContain("two diamonds", game);
            Assert.DoesNotContain("king clubs", game);
            Assert.DoesNotContain("ace hearts", game);
            Assert.DoesNotContain("ace spades", game);
            Assert.DoesNotContain("three hearts", game);
        }

        [Fact]
        public void MoreThrownCardsThanInGameTest()
        {
            // Arrange
            int numberOfCardsInGame = 2;
            var cardsToThrow = new List<string> { "two diamonds", "king clubs", "queen hearts" };

            // Act and assert
            Assert.Throws<MoreThrownCardsThanGameCardsLeftBadRequestException>(() =>
            cardsInHandService.MoreThrownCardsThanInGame(numberOfCardsInGame, cardsToThrow));
        }

        [Fact]
        public void CardsInGameNotFoundTest()
        {
            // Arrange
            var gameId = new Guid("d33025da-6a44-44a5-8586-c048e16da282");

            // Act and assert
            Assert.Throws<CardsInGameNotFoundException>(() =>
            cardsInHandService.CardsInGameNotFound(gameId));
        }

        [Fact]
        public void NumberOfCardsNotAllowedTest()
        {
            // Arrange
            int numberOfCardsToThrow = 6;

            // Act and assert
            Assert.Throws<NumberOfCardsNotAllowedBadRequestException>(() =>
            cardsInHandService.NumberOfCardsNotAllowed(numberOfCardsToThrow));
        }

        [Fact]
        public void NoDuplicatesAllowedTest()
        {
            // Arrange
            var cardIds = new List<Guid> { new Guid("a5662f6c-9ae9-48d7-a5ce-c48123932e77"),
                            new Guid("a5662f6c-9ae9-48d7-a5ce-c48123932e77") };

            // Act and assert
            Assert.Throws<NoDuplicateIdsBadRequestException>(() =>
            cardsInHandService.NoDuplicatesAllowed(cardIds));
        }

        [Fact]
        public void CardInHandNotFoundTest()
        {
            // Arrange
            var cardIds = new List<Guid> { new Guid("2e808d76-635a-4175-86aa-c6899e8bfe8d"),
                            new Guid("3d7ed67f-d48b-4cc5-a40c-3d3177b3e876") };

            var previousHandId = new Guid("1d7b859c-ac86-4fec-b927-f8dc82b5a56a");

            // Act and assert
            Assert.Throws<CardInHandNotFoundException>(() =>
            cardsInHandService.CardInHandNotFound(cardIds, previousHandId));

        }

        [Fact]
        public void HandNotFoundTest()
        {
            // Arrange 
            var handId = new Guid("2dd95553-6daf-49c5-9e45-842596a1547e");

            // Act and assert
            Assert.Throws<HandNotFoundException>(() =>
            cardsInHandService.HandNotFound(handId));
        }

        [Fact]

        public void NoCardsTest()
        {
            // Arrange
            var cards = new List<Card>();

            // Act and assert
            Assert.Throws<NoCardsBadRequestException>(() =>
            cardsInHandService.NoCards(cards));
        }
    }
}
