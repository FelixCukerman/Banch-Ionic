using System.Collections.Generic;

namespace BookStore.ViewModelsLayer.ViewModels.AdministrationManagementViewModels
{
    public class ResponseGetUsersViewModel
    {
        public List<ResponseGetUserViewModelItem> Users { get; set; }
        public int Count { get; set; }

        public ResponseGetUsersViewModel()
        {
            Users = new List<ResponseGetUserViewModelItem>();
        }
    }

    public class ResponseGetUserViewModelItem
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
