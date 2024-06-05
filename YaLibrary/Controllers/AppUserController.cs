using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YaLibrary.Models;

namespace YaLibrary.Controllers
{
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AppUserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<AppUser> CreateUser(AppUser newUser, string password)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser));

            var result = await userManager.CreateAsync(newUser, password);
            
            if (result.Succeeded)
                return newUser;
            else
                throw new InvalidOperationException($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}
