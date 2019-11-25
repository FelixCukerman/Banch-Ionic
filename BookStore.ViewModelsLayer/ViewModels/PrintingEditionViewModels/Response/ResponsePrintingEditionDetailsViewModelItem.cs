using BookStore.Shared.Enums;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Response.Base;

namespace BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels
{
    public class PrintingEditionDetailsViewModelItem : BaseResponsePrintingEditionViewModelItem
    {
        public string Description { get; set; }
        public PrintingEditionType Type { get; set; }
    }
}