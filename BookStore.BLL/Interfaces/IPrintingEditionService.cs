using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels;
using System.Threading.Tasks;

namespace BookStore.BLL.Interfaces
{
    public interface IPrintingEditionService
    {
        Task CreateTestBooks();
        Task<ResponsePrintingEditionPreviewViewModel> GetBooks(int index, int count);
    }
}
