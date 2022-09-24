namespace RandomCards.Models
{
    public class CardGame
    {
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public Card Card { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
