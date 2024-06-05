//using YaLibrary.Data;
//using YaLibrary.Models;

//namespace YaLibrary.Helper
//{
//    public static class DataSeeder
//    {
//        public static void SeedBooks(ApplicationDbContext context)
//        {
//            if (!context.Books.Any())
//            {
//                var books = new List<Book>
//            {
//                new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopian", ISBN = "978-0451524935", Available = GetRandomAvailability() },
//                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", ISBN = "978-0060935467", Available = GetRandomAvailability() },
//                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", ISBN = "978-1503290563", Available = GetRandomAvailability() },
//                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction", ISBN = "978-0743273565", Available = GetRandomAvailability() },
//                new Book { Title = "Moby-Dick", Author = "Herman Melville", Genre = "Adventure", ISBN = "978-1503280786", Available = GetRandomAvailability() },
//                new Book { Title = "War and Peace", Author = "Leo Tolstoy", Genre = "Historical", ISBN = "978-1505572831", Available = GetRandomAvailability() },
//                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction", ISBN = "978-0316769488", Available = GetRandomAvailability() },
//                new Book { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Genre = "Crime", ISBN = "978-0486415871", Available = GetRandomAvailability() },
//                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", ISBN = "978-0547928227", Available = GetRandomAvailability() },
//                new Book { Title = "Brave New World", Author = "Aldous Huxley", Genre = "Dystopian", ISBN = "978-0060850524", Available = GetRandomAvailability() },
//                new Book { Title = "Jane Eyre", Author = "Charlotte Bronte", Genre = "Romance", ISBN = "978-1503278196", Available = GetRandomAvailability() },
//                new Book { Title = "The Odyssey", Author = "Homer", Genre = "Epic", ISBN = "978-0140268867", Available = GetRandomAvailability() },
//                new Book { Title = "The Divine Comedy", Author = "Dante Alighieri", Genre = "Epic", ISBN = "978-0142437223", Available = GetRandomAvailability() },
//                new Book { Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", Genre = "Philosophical", ISBN = "978-0374528379", Available = GetRandomAvailability() },
//                new Book { Title = "Wuthering Heights", Author = "Emily Bronte", Genre = "Gothic", ISBN = "978-1505313108", Available = GetRandomAvailability() },
//                new Book { Title = "Hamlet", Author = "William Shakespeare", Genre = "Tragedy", ISBN = "978-1980625025", Available = GetRandomAvailability() },
//                new Book { Title = "The Iliad", Author = "Homer", Genre = "Epic", ISBN = "978-0140275360", Available = GetRandomAvailability() },
//                new Book { Title = "Anna Karenina", Author = "Leo Tolstoy", Genre = "Romance", ISBN = "978-1505577310", Available = GetRandomAvailability() },
//                new Book { Title = "The Count of Monte Cristo", Author = "Alexandre Dumas", Genre = "Adventure", ISBN = "978-0140449266", Available = GetRandomAvailability() },
//                new Book { Title = "Great Expectations", Author = "Charles Dickens", Genre = "Fiction", ISBN = "978-1505299633", Available = GetRandomAvailability() },
//            };

//                context.Books.AddRange(books);
//                context.SaveChanges();
//            }
//        }

//        private static bool GetRandomAvailability()
//        {
//            var random = new Random();
//            return random.NextDouble() < 0.75;
//        }
//    }
//}
