namespace RandomCards.Exceptions
{
    public sealed class CardInHandNotFoundException : NotFoundException
    {
        public CardInHandNotFoundException(Guid cardId, Guid handId)
            : base($"The card with id: {cardId} or the hand with id: {handId} does not exist.")
        {
        }
    }
}
