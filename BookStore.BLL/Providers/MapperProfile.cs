using AutoMapper;
using BookStore.EL.Entities;
using BookStore.Shared.RequestModels;
using BookStore.ViewModelsLayer.ViewModels.AccountViewModels;
using BookStore.ViewModelsLayer.ViewModels.AdministrationManagementViewModels;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Response.Base;
using EntitiesLayer.Entities;
using System.Collections.Generic;

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

            CreateMap<RequestGetProductsViewModel, RequestGetProductsModel>();
            CreateMap<RequestGetProductsModel, RequestGetProductsViewModel>();

            CreateMap<RequestCreateBookViewModel, Book>();

            CreateMap<Book, ResponseGetProductsViewModelItem>().ForMember(destination => destination.Authors, opt => opt.Ignore());
            CreateMap<List<Book>, ResponseGetProductsViewModel>().ForMember(destination => destination.Products, opt => opt.MapFrom(data => data));

            CreateMap<ResponseGetUserViewModelItem, User>();
            CreateMap<User, ResponseGetUserViewModelItem>().ForMember(destination => destination.Status, opt => opt.Ignore());

            CreateMap<User, GetUsersListViewModelItem>().ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.UserName));
            CreateMap<RequestEditUserViewModelItem, User>().ForMember(destination => destination.UserName, opt => opt.MapFrom(source => source.Name));
        }
    }
}