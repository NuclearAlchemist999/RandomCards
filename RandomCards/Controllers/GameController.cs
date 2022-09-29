using Microsoft.AspNetCore.Mvc;
using RandomCards.Requests;
using RandomCards.Services.CardService;

namespace RandomCards.Controllers
{
    /// <summary>
    /// Controller with three methods. Service injected.
    /// </summary>
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ICardService _cardService;

        public GameController(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// GET Will initialize the game. Will use the base url. No parameters required.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> InitializeGame()
        {
            var hand = await _cardService.InitializeGame();

            return Ok(hand);
        }

        /// <summary>
        /// POST Will be running after a game is initialized. Game id is required in the url and a model parameter from the body.
        /// Hand after the game id in the url since it is a ExtendedHandInfoDto that will be returned.
        /// </summary>
        [HttpPost("{gameId:guid}/hands")]
        public async Task<IActionResult> AddNewCardsInHand([FromBody] ThrowCardsRequest request, Guid gameId)
        {
            var hand = await _cardService.AddNewCardsInHand(request, gameId);
            return Ok(hand);
        }

        /// <summary>
        /// GET No parameters required. History added in the url.
        /// </summary>
        [HttpGet("history")]
        public async Task<IActionResult> GetHands()
        {
            var hands = await _cardService.GetHands();

            return Ok(hands);
        }
    }
}
