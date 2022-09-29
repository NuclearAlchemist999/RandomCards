namespace RandomCards.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        /// <summary>
        /// All Not found exceptions will inherit from here.
        /// </summary>
        protected NotFoundException(string message) : base(message)
        {
        }
    }
}
