namespace RandomCards.Exceptions
{
    public sealed class NoCardsBadRequestException : BadRequestException
    {
        public NoCardsBadRequestException()
            : base("There are no cards yet.")
        {
        }
    }
}
