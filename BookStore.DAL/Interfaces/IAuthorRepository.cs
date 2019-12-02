using EntitiesLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<List<Author>> GetAuthorsByIds(List<int> authorsIds);
        Task<List<Author>> GetAuthorsByNames(List<string> authorsNames);
    }
}
