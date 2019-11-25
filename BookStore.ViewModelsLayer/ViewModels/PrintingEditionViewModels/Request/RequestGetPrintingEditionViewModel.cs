using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Request.Base;

namespace BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Request
{
    public class RequestGetPrintingEditionViewModel : BaseRequestGetPrintingEditionViewModel
    {
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
