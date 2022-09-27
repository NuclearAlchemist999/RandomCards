namespace RandomCards.Exceptions
{
    public sealed class CardsInGameNotFoundException : NotFoundException
    {
        public CardsInGameNotFoundException(Guid gameId)
            : base($"The cards in the game with id: {gameId} do not exist.")
        {
        }
    }
}
