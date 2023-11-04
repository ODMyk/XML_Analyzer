namespace XML_Manager;

public struct FilterOptions
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public string Genre { get; set; }

    public string Year { get; set; }

    public FilterOptions()
    {
        Title = "";
        Description = "";
        Author = "";
        Genre = "";
        Year = "";
    }

    public readonly bool ValidateBook(Book book) {
        var title = book.Title.ToLower().Contains(Title.ToLower());
        var year = book.Year.ToLower().Contains(Year.ToLower());
        var description = book.Description.ToLower().Contains(Description.ToLower());
        var genre = book.Genre.ToLower().Contains(Genre.ToLower());
        var author = (book.Author.FirstName + " " + book.Author.LastName).ToLower().Contains(Author.ToLower());

        return title && year && description && genre && author;
    }
}