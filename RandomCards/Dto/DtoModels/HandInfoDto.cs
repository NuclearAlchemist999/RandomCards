namespace RandomCards.Dto.DtoModels
{
    /// <summary>
    /// The primary Dto in the entire application.
    /// </summary>
    public class HandInfoDto
    {
        public Guid GameId { get; set; }
        public Guid HandId { get; set; }
        public List<CardDto> Cards { get; set; }
    }
}
