namespace RandomCards.Models
{
    public class Hand
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public List<CardHand> CardHands { get; set; }
        public string TimeStamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
