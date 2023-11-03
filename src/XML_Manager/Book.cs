namespace XML_Manager;

public class Book
{
    public class BookAuthor
    {
        public BookAuthor() {
            FirstName = "";
            LastName = "";
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
    public Book() {
        Title = "";
        Description = "";
        Year = "";
        Genre = "";
        Author = new();
    }
    public string Title { get; set; }

    public string Description { get; set; }

    public string Year { get; set; }

    public BookAuthor Author { get; set; }

    public string Genre { get; set; }
}