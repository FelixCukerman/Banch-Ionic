using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BLL.Interfaces;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Request;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Response.Base;
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

        [HttpPost("getbyfilter")]
        public async Task<ResponsePrintingEditionPreviewViewModel> GetBooks([FromBody]RequestGetPrintingEditionViewModel requestModel)
        {
            ResponsePrintingEditionPreviewViewModel books = await _printingEditionService.GetBooks(requestModel);

            return books;
        }

        [HttpGet("{id}")]
        public async Task<BaseResponsePrintingEditionViewModelItem> GetBooks(int id)
        {
            BaseResponsePrintingEditionViewModelItem book = await _printingEditionService.GetBook(id);

            return book;
        }
    }
}