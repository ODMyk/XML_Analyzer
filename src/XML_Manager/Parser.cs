namespace XML_Manager;

public abstract class Parser : IParser
{
    protected IList<Book> Books;
    public IList<Book> Find(FilterOptions filters)
    {
        return Books.Where(filters.ValidateBook).ToList();

    }

    public abstract bool Load(Stream inputstream);
}