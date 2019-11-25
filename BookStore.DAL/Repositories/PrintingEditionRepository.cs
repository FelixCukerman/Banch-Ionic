using BookStore.DAL.Interfaces;
using BookStore.Shared.RequestModels;
using BookStore.Shared.RequestModels.Base;
using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class PrintingEditionRepository : GenericRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(StoreContext data) : base(data)
        {
        }

        public async Task<int> GetTotalCount(BaseRequestGetBooksModel requestModel)
        {
            Expression<Func<PrintingEdition, bool>> expression = null;

            int totalCount;

            bool filterHasPrintingEditionTypes = !requestModel.PrintingEditionTypes.Count.Equals(default(int));

            if (requestModel.Equals(null))
            {
                return default(int);
            }

            if(!filterHasPrintingEditionTypes)
            {
                expression = book => book.Price >= requestModel.MinPrice && book.Price <= requestModel.MaxPrice;
            }

            if(filterHasPrintingEditionTypes)
            {
                expression = book => book.Price >= requestModel.MinPrice && book.Price <= requestModel.MaxPrice && requestModel.PrintingEditionTypes.Contains(book.Type);
            }

            totalCount = await _data.PrintingEditions.Where(expression).CountAsync();

            return totalCount;
        }

        public async Task<List<PrintingEdition>> GetByFilters(RequestGetBooksModel requestModel)
        {
            List<PrintingEdition> books;

            if (requestModel.PrintingEditionTypes.Count.Equals(default(int)))
            {
                books = await _data.PrintingEditions
                              .Where(book => book.Price >= requestModel.MinPrice && book.Price <= requestModel.MaxPrice)
                              .Skip(requestModel.Index)
                              .Take(requestModel.Count)
                              .ToListAsync();

                return books;
            }

            books = await _data.PrintingEditions
                          .Where(book => book.Price >= requestModel.MinPrice && book.Price <= requestModel.MaxPrice && requestModel.PrintingEditionTypes
                          .Contains(book.Type))
                          .Skip(requestModel.Index)
                          .Take(requestModel.Count)
                          .ToListAsync();

            return books;
        }
    }
}
