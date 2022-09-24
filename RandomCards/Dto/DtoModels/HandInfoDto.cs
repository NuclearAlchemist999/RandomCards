namespace RandomCards.Dto.DtoModels
{
    public class HandInfoDto
    {
        public Guid GameId { get; set; }
        public Guid HandId { get; set; }
        public List<CardDto> Cards { get; set; }
    }
}
