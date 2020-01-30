using BookStore.Shared.Enums;
using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.AdministrationManagementViewModels
{
    public class ResponseGetProductsViewModel
    {
        public List<ResponseGetProductsViewModelItem> Products { get; set; }
        public int Count { get; set; }
    }

    public class ResponseGetProductsViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PrintingEditionType Category { get; set; }
        public double Price { get; set; }
        public List<string> Authors { get; set; }

        public ResponseGetProductsViewModelItem()
        {
            Authors = new List<string>();
        }
    }
}
