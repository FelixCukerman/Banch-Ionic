using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels
{
    public class ResponsePrintingEditionPreviewViewModel
    {
        public List<PrintingEditionPreviewViewModelItem> Data { get; set; }
        public int TotalCount { get; set; }
    }
    public class PrintingEditionPreviewViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public List<string> Authors { get; set; }
        public string Image { get; set; }
        public PrintingEditionPreviewViewModelItem()
        {
            Authors = new List<string>();
        }
    }
}