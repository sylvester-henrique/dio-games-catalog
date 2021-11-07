using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIO.GamesCatalog.Api.Repositories
{
    public interface IRepository<T>
    {
        Task<int> InsertAsync(T game);
        Task<IEnumerable<T>> ListAsync(int? id = null);
        Task UpdateAsync(T game);
        Task DeleteAsync(int id);
    }
}
