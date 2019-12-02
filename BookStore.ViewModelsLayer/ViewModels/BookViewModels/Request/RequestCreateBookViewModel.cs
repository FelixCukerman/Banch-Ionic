using BookStore.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request
{
    public class RequestCreateBookViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PrintingEditionType Type { get; set; }
        public List<string> Authors { get; set; }
        public double Price { get; set; }
        public CurrencyType Currency { get; set; }
        public string Status { get; set; }
        public IFormFile Image { get; set; }
    }
}
