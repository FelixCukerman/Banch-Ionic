using BookStore.DAL.Interfaces;
using BookStore.EL.Entities;
using BookStore.Shared.Enums;
using EntitiesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.DAL
{
    public class StoreDbInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly IBookRepository _bookRepository;
        public StoreDbInitializer(UserManager<User> userManager, IBookRepository bookRepository)
        {
            _userManager = userManager;
            _bookRepository = bookRepository;
        }

        public async Task Initialize()
        {
            int userCount = await _userManager.Users.CountAsync();
            if (userCount == default(int))
            {
                await InitializeUsers();
            }

            int booksCount = await _bookRepository.GetCount();
            if(booksCount == default(int))
            {
                await InitializeBooks();
            }
        }

        private async Task InitializeUsers()
        {
            var admin = new User { Email = "admin@admin.com", UserName = "Admin" };
            IdentityResult result = await _userManager.CreateAsync(admin, "admin123");
        }

        private async Task InitializeBooks()
        {
            var booksToCreate = new Book()
            {
                Currency = CurrencyType.EUR,
                Description = $"Ipsum",
                IsRemoved = false,
                Name = $"Loren",
                Price = 13,
                Status = $"Ipsum",
                Category = PrintingEditionType.Book,
            };

            await _bookRepository.Create(booksToCreate);
        }
    }
}