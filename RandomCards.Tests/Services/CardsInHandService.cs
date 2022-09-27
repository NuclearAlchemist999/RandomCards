using RandomCards.Exceptions;
using RandomCards.Models;

namespace RandomCards.Tests.Services
{
    public class CardsInHandService
    {
        public List<string> games = new List<string>();
        public List<string> cards = new List<string>();
        public List<string> hands = new List<string>();

        public List<string> AddCardsInNewhand(List<string> cardsToThrow)
        {
            var previousHand = PreviousHand();

            var newhand = new List<string>();

            foreach (var card in previousHand)
            {
                newhand.Add(card);
            }

            foreach (var card in cardsToThrow)
            {
                var random = new Random();
                var randNumb = random.Next(games.Count());
                var randCard = games[randNumb];

                games.Remove(randCard);

                newhand.Remove(card);
                newhand.Add(randCard);
            }

            return newhand;
        }

        public List<string> PreviousHand()
        {
            var cards = AddCards();

            foreach (var card in cards)
            {
                games.Add(card);
            }

            var previousHand = new List<string> { "two diamonds", "ace hearts", "king clubs", "three hearts", "ace spades" };

            foreach (var card in previousHand)
            {
                games.Remove(card);
            }

            return previousHand;
        }

        public List<string> AddCards()
        {
            List<string> suits = new List<string> { "spades", "diamonds", "clubs", "hearts" };
            List<string> values = new List<string> { "ace", "two", "three", "four", "five", "six",
        "seven", "eight", "nine", "ten", "jack", "queen", "king" };

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    var cardName = value + " " + suit;
                    cards.Add(cardName);
                }
            }

            return cards;
        }

        public void MoreThrownCardsThanInGame(int numberIfCardsInGame, List<string> cardsToThrow)
        {
            if (numberIfCardsInGame < cardsToThrow.Count())
            {
                throw new MoreThrownCardsThanGameCardsLeftBadRequestException();
            }
        }

        public void CardsInGameNotFound(Guid gameId)
        {
            List<CardGame> cards = new List<CardGame>
            {
                new CardGame
                {
                    Id = Guid.NewGuid(),
                    CardId = Guid.NewGuid(),
                    GameId = Guid.NewGuid()
                },
                new CardGame
                {
                    Id = Guid.NewGuid(),
                    CardId = Guid.NewGuid(),
                    GameId = Guid.NewGuid(),
                },
            };

            var cardsInGame = cards.Where(x => x.GameId == gameId).ToList();

            if (cardsInGame.Count == 0)
            {
                throw new CardsInGameNotFoundException(gameId);
            }
        }

        public void NumberOfCardsNotAllowed(int numberOfCardsToThrow)
        {
            if (numberOfCardsToThrow > 5 || numberOfCardsToThrow < 1)
            {
                throw new NumberOfCardsNotAllowedBadRequestException();
            }
        }

        public void NoDuplicatesAllowed(List<Guid> cardIds)
        {
            var hashset = new HashSet<Guid>();

            foreach (var cardId in cardIds)
            {
                if (!hashset.Add(cardId))
                {
                    throw new NoDuplicateIdsBadRequestException();
                }
            }
        }

        public void CardInHandNotFound(List<Guid> cardIds, Guid previousHandId)
        {
            List<CardHand> cards = new List<CardHand>
            {
                new CardHand
                {
                    Id = Guid.NewGuid(),
                    CardId = Guid.NewGuid(),
                    HandId = Guid.NewGuid()
                },
                new CardHand
                {
                    Id = Guid.NewGuid(),
                    CardId = Guid.NewGuid(),
                    HandId = Guid.NewGuid()
                },
            };

            foreach (var cardId in cardIds)
            {
                var card = cards.FirstOrDefault(x => x.CardId == cardId && x.HandId == previousHandId);

                if (card == null)
                {
                    throw new CardInHandNotFoundException(cardId, previousHandId);
                }
            }
        }

        public void HandNotFound(Guid handId)
        {
            List<Hand> hands = new List<Hand>
            {
                new Hand
                {
                    Id = Guid.NewGuid(),
                    GameId = Guid.NewGuid(),
                },
                new Hand
                {
                    Id = Guid.NewGuid(),
                    GameId = Guid.NewGuid(),
                },
            };

            var hand = hands.FirstOrDefault(x => x.Id == handId);

            if (hand == null)
            {
                throw new HandNotFoundException(handId);
            }
        }

        public void NoCards(List<Card> cards)
        {
            if (cards.Count == 0)
            {
                throw new NoCardsBadRequestException();
            }
        }
    }
}
