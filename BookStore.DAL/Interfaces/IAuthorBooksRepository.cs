using EntitiesLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IAuthorBooksRepository : IRepository<AuthorBooks>
    {
        Task<List<AuthorBooks>> GetByBooksIds(List<int> bookIds);
    }
}
