namespace RandomCards.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        /// <summary>
        /// All Bad request exceptions will inherit from here.
        /// </summary>
        protected BadRequestException(string message) : base(message)
        {
        }
    }
}
