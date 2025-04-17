using Microsoft.AspNetCore.Mvc;
using LudoGame.Api.Models;
using LudoGame.Api.Store;
using LudoGame.Core;
using LudoGame.Core.Dice;
using LudoGame.Core.Enums;

namespace LudoGame.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class GamesController : ControllerBase
    {
        private readonly IGameStore _store;
        private readonly IDice _dice;

        public GamesController(IGameStore store, IDice dice)
        {
            _store = store;
            _dice = dice;
        }

        /// <summary>
        /// Opretter et nyt spil med angivne spillerfarver.
        /// </summary>
        /// <param name="req">Array af farver (2‑4 spillere)</param>
        [HttpPost]
        public ActionResult<Guid> Create([FromBody] CreateGameRequest req)
        {
            if (req.Colors.Length is < 2 or > 4)
                return BadRequest("Between 2 and 4 colors required");

            try
            {
                var colors = req.Colors.Select(c => Enum.Parse<PlayerColor>(c, true));
                var game = _store.Create(colors, _dice);
                return CreatedAtAction(nameof(Get), new { id = game.Id }, game.Id);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid color name. Use Red, Green, Yellow or Blue.");
            }
        }

        /// <summary>
        /// Returnerer nuværende spilstatus.
        /// </summary>
        [HttpGet("{id:guid}")]
        public ActionResult<GameDto> Get(Guid id)
        {
            var game = _store.Get(id);
            return game is null
                ? NotFound()
                : Ok(GameDto.From(game));
        }

        /// <summary>
        /// Udfører en spillers træk baseret på deres briks position.
        /// </summary>
        [HttpPost("{id:guid}/turn")]
        public ActionResult<GameDto> Turn(Guid id, [FromBody] TurnRequest req)
        {
            var tracked = _store.Get(id);
            if (tracked is null) return NotFound();

            try
            {
                tracked.Game.PlayTurn((player, roll) =>
                    player.Pieces.FirstOrDefault(p => p.Position == req.PiecePosition));
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid move: {ex.Message}");
            }

            return Ok(GameDto.From(tracked));
        }
    }
}
