using AutoMapper;
using BookStore.Shared.RequestModels;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Request;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Response.Base;
using EntitiesLayer.Entities;

namespace BookStore.BLL.Providers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() : base()
        {
            CreateMap<PrintingEdition, PrintingEditionDetailsViewModelItem>();
            CreateMap<PrintingEdition, BaseResponsePrintingEditionViewModelItem>();

            CreateMap<RequestGetBooksModel, RequestGetPrintingEditionViewModel>();
        }
    }
}
