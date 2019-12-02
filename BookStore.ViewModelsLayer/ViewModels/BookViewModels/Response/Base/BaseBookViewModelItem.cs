using BookStore.Shared.Enums;
using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.BookViewModels.Response.Base
{
    public class BaseBookViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Authors { get; set; }
        public double Price { get; set; }
        public CurrencyType Currency { get; set; }
        public string Image { get; set; }

        public BaseBookViewModelItem()
        {
            Authors = new List<string>();
        }
    }
}
