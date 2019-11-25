using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Request;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Response.Base;
using System.Threading.Tasks;

namespace BookStore.BLL.Interfaces
{
    public interface IPrintingEditionService
    {
        Task CreateTestBooks(int id);
        Task<ResponsePrintingEditionPreviewViewModel> GetBooks(RequestGetPrintingEditionViewModel requestViewModel);
        Task<BaseResponsePrintingEditionViewModelItem> GetBook(int id);
    }
}
