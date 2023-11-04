namespace XML_Manager;

public interface IParser
{
    public bool Load(Stream inputStream);
    public IList<Book> Find(FilterOptions filters);
}
