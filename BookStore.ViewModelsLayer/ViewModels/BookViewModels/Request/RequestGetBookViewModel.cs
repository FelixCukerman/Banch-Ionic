using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request.Base;

namespace BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request
{
    public class RequestGetBookViewModel : BaseRequestGetBookViewModel
    {
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
