using BookStore.Shared.Enums;
using BookStore.Shared.RequestModels;
using BookStore.Shared.RequestModels.Base;
using EntitiesLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<int> GetTotalCount(BaseRequestGetBooksModel requestModel);
        Task<List<Book>> GetByFilters(RequestGetBooksModel requestModel);
        Task<List<Book>> GetBooks(RequestGetProductsModel model);
    }
}