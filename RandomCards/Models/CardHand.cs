namespace RandomCards.Models
{
    public class CardHand
    {
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public Card Card { get; set; }
        public Guid HandId { get; set; }
        public Hand Hand { get; set; }
    }
}
