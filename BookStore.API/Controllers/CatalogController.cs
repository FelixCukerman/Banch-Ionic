using System.Threading.Tasks;
using BookStore.BLL.Interfaces;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IBookService _bookService;

        public CatalogController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("createbook")]
        public async Task<IActionResult> CreateBook([FromBody]RequestCreateBookViewModel requestModel)
        {
            await _bookService.CreateBook(requestModel);

            return Ok();
        }

        [HttpPost("getbyfilter")]
        public async Task<ResponseBookPreviewViewModel> GetBooks([FromBody]RequestGetBookViewModel requestModel)
        {
            ResponseBookPreviewViewModel books = await _bookService.GetBooks(requestModel);

            return books;
        }

        [HttpGet("{id}")]
        public async Task<BookDetailsViewModelItem> GetBook(int id)
        {
            BookDetailsViewModelItem book = await _bookService.GetBook(id);

            return book;
        }
    }
}