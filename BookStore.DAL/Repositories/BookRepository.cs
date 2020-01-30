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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(StoreContext data) : base(data)
        {
        }

        public async Task<int> GetTotalCount(BaseRequestGetBooksModel requestModel)
        {
            Expression<Func<Book, bool>> expression = null;

            int totalCount;

            bool filterHasPrintingEditionTypes = !requestModel.PrintingEditionTypes.Count.Equals(default(int));

            if (requestModel == null)
            {
                return default(int);
            }

            if(!filterHasPrintingEditionTypes)
            {
                expression = book => book.Price >= requestModel.MinPrice && book.Price <= requestModel.MaxPrice;
            }

            if(filterHasPrintingEditionTypes)
            {
                expression = book => book.Price >= requestModel.MinPrice && book.Price <= requestModel.MaxPrice && requestModel.PrintingEditionTypes.Contains(book.Category);
            }

            totalCount = await _data.Books.Where(expression).CountAsync();

            return totalCount;
        }

        public async Task<List<Book>> GetByFilters(RequestGetBooksModel requestModel)
        {
            Expression<Func<Book, bool>> expression = null;
            List<Book> books;

            if (requestModel.PrintingEditionTypes.Count == default(int))
            {
                expression = book => book.Price >= requestModel.MinPrice && book.Price <= requestModel.MaxPrice;
            }
            if (requestModel.PrintingEditionTypes.Count != default(int))
            {
                expression = book => book.Price >= requestModel.MinPrice && book.Price <= requestModel.MaxPrice && requestModel.PrintingEditionTypes.Contains(book.Category);
            }

            books = await _data.Books.Where(expression).Skip(requestModel.Index).Take(requestModel.Count).ToListAsync();

            return books;
        }

        public async Task<List<Book>> GetBooks(RequestGetProductsModel model)
        {
            List<Book> books = await _data.Books.Skip(model.Index).Take(model.Count).ToListAsync();

            return books;
        }
    }
}