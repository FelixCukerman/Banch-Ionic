using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BLL.Interfaces;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IPrintingEditionService _printingEditionService;

        public CatalogController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        [HttpGet("{index}/{count}")]
        public async Task<ResponsePrintingEditionPreviewViewModel> Get(int index, int count)
        {
            ResponsePrintingEditionPreviewViewModel books = await _printingEditionService.GetBooks(index, count);
            return books;
        }
    }
}
