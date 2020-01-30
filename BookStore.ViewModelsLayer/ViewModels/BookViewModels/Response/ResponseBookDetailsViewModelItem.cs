using BookStore.Shared.Enums;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Response.Base;

namespace BookStore.ViewModelsLayer.ViewModels.BookViewModels
{
    public class BookDetailsViewModelItem : BaseBookViewModelItem
    {
        public string Description { get; set; }
        public string BriefDescription { get; set; }
        public PrintingEditionType Type { get; set; }
    }
}