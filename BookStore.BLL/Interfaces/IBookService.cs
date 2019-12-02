using BookStore.ViewModelsLayer.ViewModels.BookViewModels;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request;
using System.Threading.Tasks;

namespace BookStore.BLL.Interfaces
{
    public interface IBookService
    {
        Task<ResponseBookPreviewViewModel> GetBooks(RequestGetBookViewModel requestViewModel);
        Task<BookDetailsViewModelItem> GetBook(int id);
        Task CreateBook(RequestCreateBookViewModel request);
    }
}
