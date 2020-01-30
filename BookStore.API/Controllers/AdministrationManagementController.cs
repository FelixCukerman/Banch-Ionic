using System.Threading.Tasks;
using BookStore.BLL.Interfaces;
using BookStore.ViewModelsLayer.ViewModels.AccountViewModels;
using BookStore.ViewModelsLayer.ViewModels.AdministrationManagementViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/administration")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [ApiController]
    public class AdministrationManagementController : ControllerBase
    {
        private readonly IAdministrationManagementService _service;
        public AdministrationManagementController(IAdministrationManagementService administrationManagement)
        {
            _service = administrationManagement;
        }

        [HttpPost("products")]
        public async Task<ResponseGetProductsViewModel> GetProducts(RequestGetProductsViewModel request)
        {
            ResponseGetProductsViewModel result = await _service.GetProducts(request);

            return result;
        }

        [HttpGet("product/remove/{id}")]
        public async Task RemoveProduct(int id)
        {
            await _service.RemoveProduct(id);
        }

        [HttpPost("users")]
        public async Task<ResponseGetUsersViewModel> GetProducts(RequestGetUsersViewModel request)
        {
            ResponseGetUsersViewModel result = await _service.GetUsers(request);

            return result;
        }

        [HttpGet("user/remove/{id}")]
        public async Task<bool> RemoveUser(int id)
        {
            bool isSucceeded = await _service.RemoveUser(id);

            return isSucceeded;
        }

        [HttpGet("getusers")]
        public async Task<GetUsersListViewModel> GetUsersList()
        {
            GetUsersListViewModel usersList = await _service.GetUsersList();

            return usersList;
        }

        [HttpPost("edituser")]
        public async Task<bool> EditUser(RequestEditUserViewModelItem request)
        {
            bool isSucceeded = await _service.EditUser(request);

            return isSucceeded;
        }
    }
}