using DIO.GamesCatalog.Api.ApiModels.Game;
using DIO.GamesCatalog.Api.Services;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Creates a game.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(PostGameRequest postGameRequest)
        {
            var id = await _gameService.CreateAsync(postGameRequest);
            return CreatedAtAction(nameof(Get), new { id = id });
        }

        /// <summary>
        /// Get all games.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var games = await _gameService.ListAsync();
            if (!games.Any())
            {
                return NoContent();
            }

            return Ok(games);
        }

        /// <summary>
        /// Gets a game by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The game id.</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var game = (await _gameService.ListAsync(id)).SingleOrDefault();
            if (game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        /// <summary>
        /// Updates the game price.
        /// </summary>
        /// <param name="id">The game id.</param>
        /// <param name="price">The price to be set for the game.</param>
        [HttpPatch("{id}/price/{price:double}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PatchPrice(int id, double price)
        {
            await _gameService.UpdatePriceAsync(id, price);
            return Ok();
        }

        /// <summary>
        /// Updates the game inventory.
        /// </summary>
        /// <param name="id">The game id.</param>
        /// <param name="inventory">The inventory count of the game.</param>
        [HttpPatch("{id}/inventory/{inventory:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PatchInventory(int id, int inventory)
        {
            await _gameService.UpdateInventoryAsync(id, inventory);
            return Ok();
        }

        /// <summary>
        /// Deletes a game.
        /// </summary>
        /// <param name="id">The game id.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.DeleteAsync(id);
            return Ok();
        }
    }
}
