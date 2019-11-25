using BookStore.Shared.Enums;
using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Response.Base
{
    public class BaseResponsePrintingEditionViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Authors { get; set; }
        public double Price { get; set; }
        public CurrencyType Currency { get; set; }
        public string Image { get; set; }

        public BaseResponsePrintingEditionViewModelItem()
        {
            Authors = new List<string>();
        }
    }
}
