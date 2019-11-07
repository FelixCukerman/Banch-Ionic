using AutoMapper;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels;
using EntitiesLayer.Entities;

namespace BookStore.BLL.Providers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() : base()
        {
            CreateMap<PrintingEdition, PrintingEditionDetailsViewModelItem>();
            CreateMap<PrintingEdition, PrintingEditionPreviewViewModelItem>();
        }
    }
}
