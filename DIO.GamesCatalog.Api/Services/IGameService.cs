using DIO.GamesCatalog.Api.ApiModels.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIO.GamesCatalog.Api.Services
{
    public interface IGameService
    {
        Task<int> CreateAsync(PostGameRequest postGameRequest);
        Task<IEnumerable<GetGameResponse>> ListAsync(int? id = null);
        Task UpdatePriceAsync(int id, double price);
        Task UpdateInventoryAsync(int id, int inventory);
        Task DeleteAsync(int id);
    }
}
