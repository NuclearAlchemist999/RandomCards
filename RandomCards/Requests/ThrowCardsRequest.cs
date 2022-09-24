using System.ComponentModel.DataAnnotations;

namespace RandomCards.Requests
{
    public class ThrowCardsRequest
    {
        [Required]
        public List<Guid> CardIds { get; set; }
        [Required]
        public Guid PreviousHandId { get; set; }
    }
}
