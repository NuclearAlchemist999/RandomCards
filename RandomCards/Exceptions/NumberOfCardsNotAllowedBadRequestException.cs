namespace RandomCards.Exceptions
{
    public sealed class NumberOfCardsNotAllowedBadRequestException : BadRequestException
    {
        public NumberOfCardsNotAllowedBadRequestException()
            : base("There must be one to five cards to be thrown away.")
        {
        }
    }
}
