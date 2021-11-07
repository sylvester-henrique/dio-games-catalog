using AutoMapper;
using DIO.GamesCatalog.Api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.GamesCatalog.Api.Repositories
{
    public class GameInMemoryRepository : IRepository<Game>
    {
        private int _lastId = 0;
        private readonly IMapper _mapper;

        public GameInMemoryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static readonly List<Game> _games = new List<Game>
        {
            new Game
            {
                Id = 0,
                Title = "Forza Horizon 5",
                Year = 2021,
                Developer = "Playground Games",
                Publisher = "Xbox Game Studios",
                Genre = "Racing",
                Plataform = "Xbox Series X",
                Price = null,
                Inventory = null
            }
        };

        public Task<int> InsertAsync(Game game)
        {
            game.Id = ++_lastId;
            _games.Add(game);
            return Task.FromResult(game.Id);
        }

        public Task<IEnumerable<Game>> ListAsync(int? id = null)
        {
            return Task.FromResult(_games.Where(g => id is null || g.Id == id));
        }

        public Task UpdateAsync(Game game)
        {
            var gameToUpdate = _games.Single(g => g.Id == game.Id);
            _mapper.Map(game, gameToUpdate);
            return Task.FromResult(true);
        }

        public Task DeleteAsync(int id)
        {
            var game = _games.Single(g => g.Id == id);
            _games.Remove(game);
            return Task.FromResult(true);
        }
    }
}
