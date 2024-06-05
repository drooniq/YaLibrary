using Microsoft.AspNetCore.Mvc;
using YaLibrary.Data;
using YaLibrary.Models;

namespace YaLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly YaLibraryContext context;

        public BookController(YaLibraryContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public UserBook CheckOut(Book book, AppUser user)
        {
            if(book == null || user == null)
            {
                throw new ArgumentNullException();
            }

            if(!book.Available)
            {
                throw new InvalidOperationException("Book is not available");
            }
                
            var userBook = new UserBook
            {
                SelectedBook = book,
                Customer = user,
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(7).Date
            };

            book.Available = false;
            
            context.UserBooks.Add(userBook);
            context.SaveChanges();

            return userBook;
        }
    }
}
