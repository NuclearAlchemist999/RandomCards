namespace RandomCards.Exceptions
{
    public sealed class MoreThrownCardsThanGameCardsLeftBadRequestException : BadRequestException
    {
        public MoreThrownCardsThanGameCardsLeftBadRequestException()
            : base("You cannot throw more cards than there are cards left in the game.")
        {
        }
    }
}
