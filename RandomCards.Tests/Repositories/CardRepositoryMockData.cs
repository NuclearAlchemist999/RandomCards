using RandomCards.Models;

namespace RandomCards.Tests.Repositories
{
    public class CardRepositoryMockData
    {
        public Game NewGame()
        {
            return new Game { Id = Guid.NewGuid() };

        }
        public Card NewCard()
        {
            return new Card { Id = Guid.NewGuid(), Name = "queen clubs" };
        }

        public CardGame NewCardInGame()
        {
            return new CardGame { Id = Guid.NewGuid(), CardId = NewCard().Id, GameId = NewGame().Id };
        }

        public Hand NewHand()
        {
            return new Hand { Id = Guid.NewGuid(), GameId = NewGame().Id };
        }

        public CardHand NewCardInHand()
        {
            return new CardHand { Id = Guid.NewGuid(), CardId = NewCard().Id, HandId = NewHand().Id };
        }
    }
}
