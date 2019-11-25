using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Response.Base;
using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels
{
    public class ResponsePrintingEditionPreviewViewModel
    {
        public List<BaseResponsePrintingEditionViewModelItem> Data { get; set; }
        public int TotalCount { get; set; }
    }
}