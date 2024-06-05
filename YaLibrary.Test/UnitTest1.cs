using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YaLibrary.Data;
using YaLibrary.Models;

namespace YaLibrary.Test
{
    public class UnitYaLibraryTest
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private YaLibraryContext context;

        public UnitYaLibraryTest()
        {
            var services = new ServiceCollection();

            // Register DbContext for in-memory database
            services.AddDbContext<YaLibraryContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

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

            var _context = serviceProvider.GetRequiredService<YaLibraryContext>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure the database is created
            _context.Database.EnsureCreated();
        }

        [Theory]
        [InlineData("John", "Doe", "john@doe.com", "John@1234")]
        public async Task Test_Register_User(string _firstName, string _lastName, string _email, string _passwd)
        {
            // Arrange
            var newUser = new AppUser(_firstName, _lastName, _email);
            // Act
            var result = await userManager.CreateAsync(newUser, _passwd);
            // Assert
            Assert.True(result.Succeeded);

            //// Assert
            //Assert.True(result.Succeeded);
            //var createdUser = await _userManager.FindByEmailAsync("john@doe.com");
            //Assert.NotNull(createdUser);
            //Assert.Equal("john@doe.com", createdUser.Email);
        }
    }
}