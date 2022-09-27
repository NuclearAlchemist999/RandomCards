namespace RandomCards.Exceptions
{
    public sealed class HandNotFoundException : NotFoundException
    {
        public HandNotFoundException(Guid handId)
            : base($"The hand with id: {handId} does not exist.")
        {
        }
    }
}
