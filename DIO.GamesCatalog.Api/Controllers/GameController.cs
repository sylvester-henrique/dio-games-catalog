using DIO.GamesCatalog.Api.ApiModels.Game;
using DIO.GamesCatalog.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.GamesCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostGameRequest postGameRequest)
        {
            var id = await _gameService.CreateAsync(postGameRequest);
            return CreatedAtAction(nameof(Get), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gameService.ListAsync();
            if (!games.Any())
            {
                return NoContent();
            }

            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var game = (await _gameService.ListAsync(id)).SingleOrDefault();
            if (game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPatch("{id}/price/{price:double}")]
        public async Task<IActionResult> PatchPrice(int id, double price)
        {
            await _gameService.UpdatePriceAsync(id, price);
            return Ok();
        }

        [HttpPatch("{id}/inventory/{inventory:int}")]
        public async Task<IActionResult> PatchInventory(int id, int inventory)
        {
            await _gameService.UpdateInventoryAsync(id, inventory);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.DeleteAsync(id);
            return Ok();
        }
    }
}
