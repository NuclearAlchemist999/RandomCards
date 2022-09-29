namespace RandomCards.Dto.DtoModels
{
    /// <summary>
    /// Extended HandInfoDto when cards left in the game are required.
    /// </summary>
    public class ExtendHandInfoDto : HandInfoDto
    {
        public int GameCardCount { get; set; }  
    }
}
