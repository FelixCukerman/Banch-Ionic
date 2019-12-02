using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Interfaces;
using BookStore.Shared.RequestModels;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Request;
using BookStore.ViewModelsLayer.ViewModels.BookViewModels.Response.Base;
using EntitiesLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class BookService : IBookService
    {
        #region Fields
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorBooksRepository _authorBooksRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IDropBoxManager _dropBoxManager;
        #endregion
        public BookService
        (
            IBookRepository bookRepository, 
            IAuthorBooksRepository authorBooksRepository, 
            IAuthorRepository authorRepository, 
            IMapper mapper,
            IDropBoxManager dropBoxManager)
        {
            _bookRepository = bookRepository;
            _authorBooksRepository = authorBooksRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
            _dropBoxManager = dropBoxManager;
        }
        #region Public Methods
        public async Task<ResponseBookPreviewViewModel> GetBooks(RequestGetBookViewModel requestViewModel)
        {
            RequestGetBooksModel requestModel = _mapper.Map<RequestGetBooksModel>(requestViewModel);

            List<Book> books = await _bookRepository.GetByFilters(requestModel);

            ResponseBookPreviewViewModel result = await GetMappedBooks(books, requestModel);

            return result;
        }

        public async Task<BookDetailsViewModelItem> GetBook(int id)
        {
            Book book = await _bookRepository.Get(id);

            List<AuthorBooks> authorBooks = await _authorBooksRepository.GetByBooksId(book.Id);
            List<int> authorsIds = authorBooks.Where(item => item.AuthorId != null).Select(item => (int)item.AuthorId).Distinct().ToList();

            List<Author> authors = await _authorRepository.GetAuthorsByIds(authorsIds);

            List<string> authorsNames = authors.Select(m => m.Name).ToList();

            BookDetailsViewModelItem result = _mapper.Map<BookDetailsViewModelItem>(book);

            result.Authors.AddRange(authorsNames);
            result.Image = await _dropBoxManager.GetFileLink(1);

            return result;
        }

        public async Task CreateBook(RequestCreateBookViewModel request)
        {
            Book book = _mapper.Map<Book>(request);

            await _bookRepository.Create(book);

            List<Author> authors = await _authorRepository.GetAuthorsByNames(request.Authors);

            IEnumerable<string> authorsNames = authors.Select(author => author.Name);

            IEnumerable<string> uncreatedAuthors = request.Authors.Except(authorsNames);

            var authorsToCreate = new List<Author>();

            foreach(string item in uncreatedAuthors)
            {
                var authorToCreate = new Author();
                authorToCreate.Name = item;

                authorsToCreate.Add(authorToCreate);
            }

            if(authorsToCreate.Count != default(int))
            {
                await _authorRepository.CreateRange(authorsToCreate);

                authors.AddRange(authorsToCreate);
            }

            var authorsBooksToCreate = new List<AuthorBooks>();

            foreach(Author author in authors)
            {
                var authorBookToCreate = new AuthorBooks();

                authorBookToCreate.AuthorId = author.Id;
                authorBookToCreate.BookId = book.Id;

                authorsBooksToCreate.Add(authorBookToCreate);
            }

            if(authorsBooksToCreate.Count != default(int))
            {
                await _authorBooksRepository.CreateRange(authorsBooksToCreate);
            }
        }
        #endregion

        #region Private Methods
        private async Task<ResponseBookPreviewViewModel> GetMappedBooks(List<Book> books, RequestGetBooksModel requestModel)
        {
            List<int> booksIds = books.Select(book => book.Id).ToList();

            List<AuthorBooks> authorBooks = await _authorBooksRepository.GetByBooksIds(booksIds);
            List<int> authorsIds = authorBooks.Where(item => item.AuthorId != null).Select(item => (int)item.AuthorId).Distinct().ToList();

            List<Author> authors = await _authorRepository.GetAuthorsByIds(authorsIds);

            ResponseBookPreviewViewModel result = await MapBookToPreviewViewModel(books, authorBooks, authors);
            result.TotalCount = await _bookRepository.GetTotalCount(requestModel);

            return result;
        }

        private async Task<ResponseBookPreviewViewModel> MapBookToPreviewViewModel(List<Book> books, List<AuthorBooks> authorBooks, List<Author> authors)
        {
            var result = new ResponseBookPreviewViewModel();
            result.Data = new List<BaseBookViewModelItem>();

            foreach(Book book in books)
            {
                List<string> booksToResult = GetAuthorsByBook(book, authorBooks, authors);

                var toResult = new BaseBookViewModelItem();

                toResult = _mapper.Map<BaseBookViewModelItem>(book);

                toResult.Authors.AddRange(booksToResult);
                toResult.Image = await _dropBoxManager.GetFileLink(1);

                result.Data.Add(toResult);
            }

            return result;
        }

        private List<string> GetAuthorsByBook(Book book, List<AuthorBooks> authorBooks, List<Author> authors)
        {
            IEnumerable<AuthorBooks> currentAuthorBooks = authorBooks.Where(item => item.BookId == book.Id);
            IEnumerable<int> currentAuthorsIds = currentAuthorBooks.Select(item => (int)item.AuthorId);

            List<string> currentAuthors = authors.Where(author => currentAuthorsIds.Contains(author.Id)).Select(author => author.Name).ToList();

            return currentAuthors;
        }
        #endregion
    }
}
