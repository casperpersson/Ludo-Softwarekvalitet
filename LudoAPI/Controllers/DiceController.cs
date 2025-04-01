using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LudoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceController : ControllerBase
    {
        [HttpGet("roll")]
        public IActionResult RollDice()
        {
            Dice dice = new Dice();
            int result = dice.Roll();
            return Ok(new { result });
        }
    }
}
