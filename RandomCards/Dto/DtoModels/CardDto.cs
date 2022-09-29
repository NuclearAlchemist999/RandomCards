namespace RandomCards.Dto.DtoModels
{
    /// <summary>
    /// A Dto for every card in a hand.
    /// </summary>
    public class CardDto
    {
        public Guid CardId { get; set; }
        public string CardName { get; set; }
    }
}
