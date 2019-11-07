using BookStore.DAL.Interfaces;
using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class PrintingEditionRepository : GenericRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(StoreContext data) : base(data)
        {
        }

        public async Task<List<PrintingEdition>> Get(int index, int count)
        {
            List<PrintingEdition> books = await _data.PrintingEditions.Skip(index).Take(count).ToListAsync();
            
            return books;
        }

        public async Task<int> GetTotalCount()
        {
            int totalCount = await _data.PrintingEditions.CountAsync();

            return totalCount;
        }
    }
}
