using AutoMapper;
using BookStore.Shared.RequestModels;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Response.Base;
using EntitiesLayer.Entities;

namespace BookStore.BLL.Providers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() : base()
        {
            CreateMap<Book, BookDetailsViewModelItem>().ForMember(destination => destination.Image, opt => opt.Ignore())
                                                                             .ForMember(destination => destination.Authors, opt => opt.Ignore());

            CreateMap<Book, BaseBookViewModelItem>().ForMember(destination => destination.Image, opt => opt.Ignore())
                                                                                  .ForMember(destination => destination.Authors, opt => opt.Ignore());

            CreateMap<RequestGetBooksModel, RequestGetBookViewModel>();

            CreateMap<RequestCreateBookViewModel, Book>();
        }
    }
}
