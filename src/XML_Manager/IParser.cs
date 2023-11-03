namespace XML_Manager;

public interface IParser
{
    public IList<Book> Find(FilterOptions filters);
}
