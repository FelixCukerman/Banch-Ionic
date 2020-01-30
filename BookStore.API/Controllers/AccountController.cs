using BookStore.BLL.Interfaces;
using BookStore.ViewModelsLayer.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<GetTokenViewModel> Login(LoginViewModel model)
        {
            var result = await _service.GetToken(model);
            return result;
        }

        [HttpPost]
        [Route("register")]
        public async Task Register(RegisterUserViewModel model)
        {
            await _service.CreateUser(model);
        }
    }
}