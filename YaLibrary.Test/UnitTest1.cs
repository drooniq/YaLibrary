using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YaLibrary.Data;
using YaLibrary.Models;
using Microsoft.Extensions.Logging;
using YaLibrary.Controllers;

namespace YaLibrary.Test
{
    public class UnitYaLibraryTest
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private YaLibraryContext context;

        private List<AppUser> users = new List<AppUser>();
        private List<Book> books = new List<Book>();

        public UnitYaLibraryTest()
        {
            var services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder.AddConsole(); // Example logging provider, you can replace it with any other provider you prefer
            });

            // Register DbContext for in-memory database
            services.AddDbContext<YaLibraryContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Scoped);
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<YaLibraryContext>()
                .AddDefaultTokenProviders();

            var serviceProvider = services.BuildServiceProvider();

            context = serviceProvider.GetRequiredService<YaLibraryContext>();
            userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure the database is created
            context.Database.EnsureCreated();

            SeedUsers();
            SeedBooks();
        }

        private void SeedUsers()
        {
            var user1 = new AppUser("John", "Doe", "john.doe@john.com");
            var user2 = new AppUser("Jane", "Doe", "jane.doe@jane.com");

            users.Add(user1);
            users.Add(user2);
        }

        private void SeedBooks()
        {             
            var book1 = new Book()
            {
                Title = "Book1",
                Author = "Author1",
                Genre = "Genre1",
                ISBN = "ISBN1",
                Available = true
            };

            var book2 = new Book()
            {
                Title = "Book2",
                Author = "Author2",
                Genre = "Genre2",
                ISBN = "ISBN2",
                Available = true
            };

            books.Add(book1);
            books.Add(book2);
        }

        [Theory]
        [InlineData("John", "Doe", "john@doe.com", "John@1234")]
        public async Task Test_Create_User(string _firstName, string _lastName, string _email, string _passwd)
        {
            // Arrange
            var userController = new AppUserController(userManager);
            var newUser = new AppUser(_firstName, _lastName, _email);
            // Act
            var createdUser = await userController.CreateUser(newUser, _passwd);
            // Assert
            Assert.Equal(newUser, createdUser);
        }

        [Theory]
        [InlineData("John", "Doe", "john@doe.com", "John@1234")]
        public async Task Test_Create_User_WithNoData(string _firstName, string _lastName, string _email, string _passwd)
        {
            // Arrange
            var userController = new AppUserController(userManager);
            var newUser = new AppUser();
            // Act
            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await userController.CreateUser(null, _passwd);
            });
        }

        [Theory]
        [InlineData(0, "john.doe@john.com", "2024-06-05", "2024-06-12")]
        public async Task Test_Checkout_Book(
            int bookIndex, string userName, DateTime checkOutDate, DateTime returnDate)
        {
            // Arrange
            var user = users.Where(s=>s.Email == userName).FirstOrDefault();
            var bookController = new BookController(context);
            var book = books[bookIndex];

            // Act
            var userBook = new UserBook()
            {
                SelectedBook = book,
                Customer = user,
                StartDate = checkOutDate,
                EndDate = returnDate
            };

            var createdUserBook = bookController.CheckOut(userBook.SelectedBook, userBook.Customer);
            // Assert
            Assert.Equal(userBook, createdUserBook);
        }
    }
}