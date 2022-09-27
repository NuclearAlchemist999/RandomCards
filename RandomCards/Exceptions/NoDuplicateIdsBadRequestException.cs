namespace RandomCards.Exceptions
{
    public sealed class NoDuplicateIdsBadRequestException : BadRequestException
    {
        public NoDuplicateIdsBadRequestException()
            : base("No duplicate ids are allowed.")
        {
        }
    }
}
