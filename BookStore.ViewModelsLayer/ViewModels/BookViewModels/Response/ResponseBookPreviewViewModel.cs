using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Response.Base;
using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.BookViewModels
{
    public class ResponseBookPreviewViewModel
    {
        public List<BaseBookViewModelItem> Data { get; set; }
        public int TotalCount { get; set; }
    }
}