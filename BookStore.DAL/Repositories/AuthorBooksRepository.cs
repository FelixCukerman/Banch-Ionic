using BookStore.DAL.Interfaces;
using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class AuthorBooksRepository : GenericRepository<AuthorBooks>, IAuthorBooksRepository
    {
        public AuthorBooksRepository(StoreContext data) : base(data)
        {
        }

        public async Task<List<AuthorBooks>> GetByBooksIds(List<int> bookIds)
        {
            List<AuthorBooks> authorBooks = await _data.AuthorBooks.Where(item => bookIds.Contains((int)item.PrintingEditionId)).ToListAsync();

            return authorBooks;
        }
    }
}
