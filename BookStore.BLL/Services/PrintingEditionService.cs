using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Interfaces;
using BookStore.Shared.Enums;
using BookStore.Shared.RequestModels;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Request;
using BookStore.ViewModelsLayer.ViewModels.PrintingEditionViewModels.Response.Base;
using EntitiesLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        #region Fields
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorBooksRepository _authorBooksRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IDropBoxManager _dropBoxManager;
        #endregion
        public PrintingEditionService
        (
            IPrintingEditionRepository printingEditionRepository, 
            IAuthorBooksRepository authorBooksRepository, 
            IAuthorRepository authorRepository, 
            IMapper mapper,
            IDropBoxManager dropBoxManager)
        {
            _printingEditionRepository = printingEditionRepository;
            _authorBooksRepository = authorBooksRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
            _dropBoxManager = dropBoxManager;
        }
        #region Public Methods
        public async Task CreateTestBooks(int id)
        {
            var booksToCreate = new PrintingEdition()
            {
                Currency = CurrencyType.EUR,
                Description = $"Ipsum{id}",
                IsRemoved = false,
                Name = $"Loren{id}",
                Price = 13 + id,
                Status = $"Ipsum{id}",
                Type = PrintingEditionType.Book,
            };

            await _printingEditionRepository.Create(booksToCreate);

            var authorBookToCreate = new AuthorBooks()
            {
                AuthorId = 1,
                PrintingEditionId = booksToCreate.Id
            };

            await _authorBooksRepository.Create(authorBookToCreate);
        }

        public async Task<ResponsePrintingEditionPreviewViewModel> GetBooks(RequestGetPrintingEditionViewModel requestViewModel)
        {
            RequestGetBooksModel requestModel = _mapper.Map<RequestGetBooksModel>(requestViewModel);

            List<PrintingEdition> books = await _printingEditionRepository.GetByFilters(requestModel);

            ResponsePrintingEditionPreviewViewModel result = await GetMappedBooks(books, requestModel);

            return result;
        }

        public async Task<BaseResponsePrintingEditionViewModelItem> GetBook(int id)
        {
            PrintingEdition book = await _printingEditionRepository.Get(id);

            List<AuthorBooks> authorBooks = await _authorBooksRepository.GetByBooksId(book.Id);
            List<int> authorsIds = authorBooks.Where(item => item.AuthorId != null).Select(item => (int)item.AuthorId).Distinct().ToList();

            List<Author> authors = await _authorRepository.GetAuthorsByIds(authorsIds);

            BaseResponsePrintingEditionViewModelItem result = await MapAuthorsToBook(book, authorBooks, authors);

            return result;

        }

        #endregion
        private async Task<ResponsePrintingEditionPreviewViewModel> GetMappedBooks(List<PrintingEdition> books, RequestGetBooksModel requestModel)
        {
            List<int> booksIds = books.Select(book => book.Id).ToList();

            List<AuthorBooks> authorBooks = await _authorBooksRepository.GetByBooksIds(booksIds);
            List<int> authorsIds = authorBooks.Where(item => item.AuthorId != null).Select(item => (int)item.AuthorId).Distinct().ToList();

            List<Author> authors = await _authorRepository.GetAuthorsByIds(authorsIds);

            ResponsePrintingEditionPreviewViewModel result = await MapAuthorsToBooks(books, authorBooks, authors);
            result.TotalCount = await _printingEditionRepository.GetTotalCount(requestModel);

            return result;
        }


        private async Task<ResponsePrintingEditionPreviewViewModel> MapAuthorsToBooks(List<PrintingEdition> books, List<AuthorBooks> authorBooks, List<Author> authors)
        {
            var result = new ResponsePrintingEditionPreviewViewModel();
            result.Data = new List<BaseResponsePrintingEditionViewModelItem>();

            foreach(PrintingEdition book in books)
            {
                var bookToResult = await MapAuthorsToBook(book, authorBooks, authors);

                result.Data.Add(bookToResult);
            }

            return result;
        }

        private async Task<BaseResponsePrintingEditionViewModelItem> MapAuthorsToBook(PrintingEdition book, List<AuthorBooks> authorBooks, List<Author> authors)
        {
            var bookToResult = new BaseResponsePrintingEditionViewModelItem();
            bookToResult.Id = book.Id;
            bookToResult.Name = book.Name;
            bookToResult.Price = book.Price;
            bookToResult.Currency = book.Currency;
            bookToResult.Image = await _dropBoxManager.GetFileLink(1); //TODO

            IEnumerable<AuthorBooks> currentAuthorBooks = authorBooks.Where(item => item.PrintingEditionId == book.Id);
            IEnumerable<int> currentAuthorsIds = currentAuthorBooks.Select(item => (int)item.AuthorId);

            List<string> currentAuthors = authors.Where(author => currentAuthorsIds.Contains(author.Id)).Select(author => author.Name).ToList();

            bookToResult.Authors.AddRange(currentAuthors);

            return bookToResult;
        }
    }
}
