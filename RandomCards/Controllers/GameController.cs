using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomCards.Dto.DtoModels;
using RandomCards.Requests;
using RandomCards.Services.CardService;

namespace RandomCards.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ICardService _cardService;

        public GameController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<IActionResult> InitializeGame()
        {
            var hand = await _cardService.InitializeGame();

            return Ok(hand);
        }

        [HttpPost("{gameId:guid}/hands")]
        public async Task<IActionResult> GetNewCardsInHand([FromBody] ThrowCardsRequest request, Guid gameId)
        {
            var hand = await _cardService.AddNewCardsInHand(request, gameId);
            return Ok(hand);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHands()
        {
            var hands = await _cardService.GetHands();

            var response = new HistoryResponseDto { HistoryItems = hands };

            return Ok(response);
        }
    }
}
