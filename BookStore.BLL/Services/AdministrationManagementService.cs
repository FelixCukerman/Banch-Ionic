using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Interfaces;
using BookStore.EL.Entities;
using BookStore.Shared.RequestModels;
using BookStore.ViewModelsLayer.ViewModels.AccountViewModels;
using BookStore.ViewModelsLayer.ViewModels.AdministrationManagementViewModels;
using EntitiesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class AdministrationManagementService : IAdministrationManagementService
    {
        private readonly UserManager<User> _userManager;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorBooksRepository _authorBooksRepository;
        private readonly IMapper _mapper; 

        public AdministrationManagementService(UserManager<User> userManager, IBookRepository bookRepository, IAuthorBooksRepository authorBooksRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _userManager = userManager;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorBooksRepository = authorBooksRepository;
            _mapper = mapper;
        }

        public async Task<ResponseGetProductsViewModel> GetProducts(RequestGetProductsViewModel request)
        {
            RequestGetProductsModel requestModel = _mapper.Map<RequestGetProductsModel>(request);

            List<Book> books = await _bookRepository.GetBooks(requestModel);

            ResponseGetProductsViewModel result = _mapper.Map<ResponseGetProductsViewModel>(books);

            List<int> booksIds = books.Select(item => item.Id).ToList();

            await MapAuthorsToBooks(result, booksIds);

            return result;
        }

        public async Task RemoveProduct(int bookId)
        {
            await _authorBooksRepository.RemoveByBookId(bookId);

            Book book = await _bookRepository.Get(bookId);

            await _bookRepository.Delete(book);
        }

        public async Task<ResponseGetUsersViewModel> GetUsers(RequestGetUsersViewModel request)
        {
            List<User> users = await _userManager.Users.Skip(request.Index).Take(request.Count).ToListAsync();

            var result = new ResponseGetUsersViewModel();
            result.Users = _mapper.Map<List<ResponseGetUserViewModelItem>>(users);

            return result;
        }

        public async Task<bool> RemoveUser(int id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());

            IdentityResult removeFromRoleResult = await _userManager.RemoveFromRoleAsync(user, "User");
            IdentityResult removeUserResult = await _userManager.DeleteAsync(user);

            bool isSucceeded = removeFromRoleResult.Succeeded && removeUserResult.Succeeded;

            return isSucceeded;
        }

        public async Task<GetUsersListViewModel> GetUsersList()
        {
            var result = new GetUsersListViewModel();

            List<User> users = await _userManager.Users.ToListAsync();
            int totalCount = await _userManager.Users.CountAsync();

            result.Data = _mapper.Map<List<GetUsersListViewModelItem>>(users);
            result.Count = totalCount;

            return result;
        }

        public async Task<bool> EditUser(RequestEditUserViewModelItem request)
        {
            User user = await _userManager.FindByIdAsync(request.Id.ToString());

            _mapper.Map(request, user);

            IdentityResult result = await _userManager.UpdateAsync(user);

            bool isSucceeded = result.Succeeded;

            return isSucceeded;
        }

        private async Task MapAuthorsToBooks(ResponseGetProductsViewModel model, List<int> booksIds)
        {
            List<AuthorBooks> authorBooks = await _authorBooksRepository.GetByBooksIds(booksIds);
            List<int> authorsIds = authorBooks.Select(item => item.AuthorId).Distinct().ToList();

            List<Author> authors = await _authorRepository.GetAuthorsByIds(authorsIds);

            foreach (var item in model.Products)
            {
                IEnumerable<AuthorBooks> currentBook = authorBooks.Where(authorBook => authorBook.BookId == item.Id);

                IEnumerable<int> currentAuthorsIds = currentBook.Select(authorBook => authorBook.AuthorId);

                List<string> currentAuthorsNames = authors.Where(author => currentAuthorsIds.Contains(author.Id)).Select(author => author.Name).ToList();

                item.Authors.AddRange(currentAuthorsNames);
            }
        }
    }
}