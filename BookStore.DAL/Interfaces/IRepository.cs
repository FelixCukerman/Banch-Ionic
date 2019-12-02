using EntitiesLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IRepository<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> Get();
        Task<int> GetCount();
        Task<T> Get(int id);
        Task Create(T item);
        Task CreateRange(IEnumerable<T> items);
        Task Update(T item);
        Task UpdateRange(IEnumerable<T> items);
        Task Delete(T t);
        Task DeleteRange(IEnumerable<T> items);
    }
}
