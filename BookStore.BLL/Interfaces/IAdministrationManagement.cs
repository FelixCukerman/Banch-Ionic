using BookStore.ViewModelsLayer.ViewModels.AccountViewModels;
using BookStore.ViewModelsLayer.ViewModels.AdministrationManagementViewModels;
using System.Threading.Tasks;

namespace BookStore.BLL.Interfaces
{
    public interface IAdministrationManagementService
    {
        Task<ResponseGetProductsViewModel> GetProducts(RequestGetProductsViewModel request);
        Task RemoveProduct(int bookId);
        Task<ResponseGetUsersViewModel> GetUsers(RequestGetUsersViewModel request);
        Task<bool> RemoveUser(int id);
        Task<GetUsersListViewModel> GetUsersList();
        Task<bool> EditUser(RequestEditUserViewModelItem request);
    }
}
