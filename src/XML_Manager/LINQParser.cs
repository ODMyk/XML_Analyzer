using System.Xml;
using System.Xml.Linq;

namespace XML_Manager;

public class LINQParser : IParser
{
    private readonly IList<Book> Books;

    public LINQParser() {
        Books = new List<Book>();
    }
    public IList<Book> Find(FilterOptions filters)
    {
        return Books.Where(filters.ValidateBook).ToList();

    }

    public bool Load(Stream inputStream)
    {
        XDocument document;
        using var reader = XmlReader.Create(inputStream, XMLValidator.Settings);
        try
        {
            document = XDocument.Load(reader);
            
            return true;
        }
        catch
        {
            return false;
        }
    }
}
