namespace RandomCards.Dto.DtoModels
{
    /// <summary>
    /// A Dto for card hand history.
    /// </summary>
    public class HistoryResponseDto
    {
        public List<HandInfoDto> HistoryItems { get; set; }
    }
}
