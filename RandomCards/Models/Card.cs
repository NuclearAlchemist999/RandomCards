namespace RandomCards.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CardGame> CardGames { get; set; }
        public List<CardHand> CardHands { get; set; }
    }
}
