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
}