namespace RandomCards.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public List<CardGame> CardGames { get; set; }
        public List<Hand> Hands { get; set; }
        public string TimeStamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
