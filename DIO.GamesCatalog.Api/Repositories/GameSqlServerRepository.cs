using DIO.GamesCatalog.Api.DatabaseContext;
using DIO.GamesCatalog.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIO.GamesCatalog.Api.Repositories
{
    public class GameSqlServerRepository : IRepository<Game>
    {
        private readonly GamesCatalogContext _gamesCatalogContext;

        public GameSqlServerRepository(GamesCatalogContext gamesCatalogContext)
        {
            _gamesCatalogContext = gamesCatalogContext;
        }

        public async Task DeleteAsync(int id)
        {
            var game = await _gamesCatalogContext.Games.FindAsync(id);
            _gamesCatalogContext.Games.Remove(game);
        }

        public async Task<int> InsertAsync(Game game)
        {
            _gamesCatalogContext.Games.Add(game);
            var id = await _gamesCatalogContext.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Game>> ListAsync(int? id = null)
        {
            if (id == null)
            {
                return await _gamesCatalogContext.Games.ToListAsync();
            }
            var game = await _gamesCatalogContext.Games.FindAsync(id);
            return new List<Game> { game };
        }

        public async Task UpdateAsync(Game game)
        {
            _gamesCatalogContext.Games.Update(game);
            await _gamesCatalogContext.SaveChangesAsync();
        }
    }
}
