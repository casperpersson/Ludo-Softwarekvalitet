using LudoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LudoAPI.Controllers
{
        [ApiController]
        [Route("api/game")]
        public class GameController : ControllerBase
        {
            [HttpPost("start")]
            public IActionResult StartGame([FromBody] GameSettings settings)
            {
                var game = new Game(settings);
                game.Initialize();
                return Ok("Game started with custom settings.");
            }
        }
}
