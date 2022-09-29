using System.ComponentModel.DataAnnotations;

namespace RandomCards.Requests
{
    /// <summary>
    /// Required parameters in the AddNewCardsInHand method.
    /// </summary>
    public class ThrowCardsRequest
    {
        [Required]
        public List<Guid> CardIds { get; set; }
        [Required]
        public Guid PreviousHandId { get; set; }
    }
}
