using BookStore.Shared.Enums;
using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request.Base
{
    public class BaseRequestGetBookViewModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<PrintingEditionType> PrintingEditionTypes { get; set; }

        public BaseRequestGetBookViewModel()
        {
            PrintingEditionTypes = new List<PrintingEditionType>();
        }
    }
}
