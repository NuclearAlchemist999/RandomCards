using RandomCards.Models;

namespace RandomCards.Tests.Repositories
{
    public class CardRepository
    {
        public List<Game> games = new List<Game>();
        public List<Card> cards = new List<Card>();
        public List<CardGame> cardGames = new List<CardGame>();
        public List<Hand> hands = new List<Hand>();
        public List<CardHand> cardHands = new List<CardHand>();

        public CardGame AddCardToGame(CardGame card)
        {
            cardGames.Add(card);

            return card;
        }

        public CardHand AddCardToHand(CardHand card)
        {
            cardHands.Add(card);
            return card;
        }

        public Game AddGame(Game game)
        {
            games.Add(game);

            return game;
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

        public Hand AddHand(Hand hand)
        {
            hands.Add(hand);
            return hand;
        }

        public CardGame GetCardByGameIdAndCardId(Guid gameId, Guid cardId)
        {
            return cardGames.FirstOrDefault(x => x.GameId == gameId && x.CardId == cardId);
        }

        public CardHand GetCardInHandByCardIdAndHandId(Guid cardId, Guid handId)
        {
            return cardHands.FirstOrDefault(x => x.CardId == cardId && x.HandId == handId);
        }

        public List<Card> GetCards()
        {
            return cards;
        }

        public List<CardGame> GetCardsByGameId(Guid id)
        {
            return cardGames.Where(x => x.GameId == id).ToList();
        }

        public Hand GetHand(Guid id)
        {
            return hands.FirstOrDefault(x => x.Id == id);
        }

        public List<Hand> GetHands()
        {
            return hands;

        }

        public Game SearchGame(Guid id)
        {
            return games.FirstOrDefault(x => x.Id == id);

        }
    }
}
