using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YaLibrary.Models;

namespace YaLibrary.Data
{
    public class YaLibraryContext : IdentityDbContext<AppUser>
    {
        public DbSet<Book> Books { get; set; } = default!;

        public YaLibraryContext (DbContextOptions<YaLibraryContext> options)
            : base(options)
        {
        }

    }
}
