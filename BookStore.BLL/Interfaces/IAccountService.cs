using BookStore.ViewModelsLayer.ViewModels.AccountViewModels;
using System.Threading.Tasks;

namespace BookStore.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<GetTokenViewModel> GetToken(LoginViewModel model);
        Task CreateUser(RegisterUserViewModel model);
    }
}
