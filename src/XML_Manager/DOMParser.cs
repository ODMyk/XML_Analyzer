using System.Xml;

namespace XML_Manager;

public class DOMParser : IParser
{
    private XmlDocument document;

    public DOMParser(Stream inputStream) {
        document = new();
        document.Load(inputStream);
    }
    public IList<Book> Find(FilterOptions filters)
    {
        throw new NotImplementedException();
    }
}
