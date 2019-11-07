using BookStore.Shared.Enums;

namespace BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels
{
    public class PrintingEditionDetailsViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public PrintingEditionType Type { get; set; }
    }
}