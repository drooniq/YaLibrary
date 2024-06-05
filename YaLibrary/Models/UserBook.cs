namespace YaLibrary.Models
{
    public class UserBook
    {
        public int Id { get; set; }
        public Book SelectedBook { get; set; }

        public AppUser Customer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}