using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.AccountViewModels
{
    public class GetUsersListViewModel
    {
        public List<GetUsersListViewModelItem> Data { get; set; }
        public int Count { get; set; }
    }

    public class GetUsersListViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}