namespace RandomCards.Models
{
    public class Hand
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public List<CardHand> CardHands { get; set; }
    }
}
