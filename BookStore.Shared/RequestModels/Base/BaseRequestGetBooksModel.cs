using BookStore.Shared.Enums;
using System.Collections.Generic;

namespace BookStore.Shared.RequestModels.Base
{
    public class BaseRequestGetBooksModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<PrintingEditionType> PrintingEditionTypes { get; set; }

        public BaseRequestGetBooksModel()
        {
            PrintingEditionTypes = new List<PrintingEditionType>();
        }
    }
}
