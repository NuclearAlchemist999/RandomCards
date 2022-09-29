using RandomCards.Models;

namespace RandomCards.Tests.Services
{
    public class CardService
    {
        public List<Game> games = new List<Game>();
        public List<Card> cards = new List<Card>();
        public List<CardGame> cardGames = new List<CardGame>();
        public List<Hand> hands = new List<Hand>();
        public List<CardHand> cardHands = new List<CardHand>();

        public Game InitializeGame()
        {
            var cards = AddCards();
            var game = AddGame();

            foreach (var card in cards)
            {
                AddCardsInGame(card.Id, game.Id);
            }

            var hand = AddHand(game.Id);

            for (int i = 0; i < 5; i++)
            {
                var randCard = GetRandomCardInGame(game.Id);

                AddCardsInHand(randCard.CardId, hand.Id);

                var deleteCard = GetCardByGameIdAndCardId(game.Id, randCard.CardId);

                DeleteCardInGame(deleteCard);
            }

            return game;
        }

        private Hand AddHand(Guid gameId)
        {
            var hand = new Hand { Id = Guid.NewGuid(), GameId = gameId };

            hands.Add(hand);

            return hand;
        }
        private Game AddGame()
        {
            var game = new Game { Id = Guid.NewGuid() };

            games.Add(game);

            return game;
        }
        private CardGame AddCardsInGame(Guid cardId, Guid gameId)
        {
            var cardGame = new CardGame { Id = Guid.NewGuid(), CardId = cardId, GameId = gameId };

            cardGames.Add(cardGame);

            return cardGame;
        }
        private CardHand AddCardsInHand(Guid cardId, Guid handId)
        {
            var handCard = new CardHand { Id = Guid.NewGuid(), CardId = cardId, HandId = handId };

            cardHands.Add(handCard);

            return handCard;
        }

        private CardGame GetRandomCardInGame(Guid gameId)
        {
            var cardsInGame = GetCardsByGameId(gameId);

            var random = new Random();
            var randNumb = random.Next(cardsInGame.Count());
            var randCard = cardsInGame[randNumb];

            return randCard;
        }

        public List<Card> AddCards()
        {
            List<string> suits = new List<string> { "spades", "diamonds", "clubs", "hearts" };
            List<string> values = new List<string> { "ace", "two", "three", "four", "five", "six",
        "seven", "eight", "nine", "ten", "jack", "queen", "king" };

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    var cardName = value + " " + suit;
                    cards.Add(new Card { Id = Guid.NewGuid(), Name = cardName });
                }
            }

            return cards;
        }

        public List<CardGame> GetCardsByGameId(Guid id)
        {
            return cardGames.Where(x => x.GameId == id).ToList();
        }

        public void DeleteCardInGame(CardGame card)
        {
            cardGames.Remove(card);
        }

        public CardGame GetCardByGameIdAndCardId(Guid gameId, Guid cardId)
        {
            return cardGames.FirstOrDefault(x => x.GameId == gameId && x.CardId == cardId);
        }

        public List<Hand> GetHandsByGameId(Guid gameId)
        {
            return hands.Where(x => x.GameId == gameId).ToList();
        }

        public List<CardHand> GetCardsInHandByHandId(Guid id)
        {
            return cardHands.Where(x => x.HandId == id).ToList();
        }

        public List<CardHand> GetHistory()
        {
            for (int i = 0; i < 5; i++)
            {
                cardHands.Add(new CardHand { Id = Guid.NewGuid(), CardId = Guid.NewGuid(), HandId = new Guid("c3e6d755-442d-49ff-8baa-77fb1ea5d329") });
            }

            return cardHands;
        }
    }
}
