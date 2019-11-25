using BookStore.Shared.Enums;
using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Request.Base
{
    public class BaseRequestGetPrintingEditionViewModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<PrintingEditionType> PrintingEditionTypes { get; set; }

        public BaseRequestGetPrintingEditionViewModel()
        {
            PrintingEditionTypes = new List<PrintingEditionType>();
        }
    }
}
