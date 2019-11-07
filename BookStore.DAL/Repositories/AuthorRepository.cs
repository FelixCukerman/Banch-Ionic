using BookStore.DAL.Interfaces;
using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(StoreContext data) : base(data)
        {
        }

        public async Task<List<Author>> GetAuthorsByIds(List<int> authorsIds)
        {
            List<Author> authors = await _data.Authors.Where(author => authorsIds.Contains(author.Id)).ToListAsync();

            return authors;
        }
    }
}
