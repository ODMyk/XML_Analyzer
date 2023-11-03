using System.Xml;

namespace XML_Manager;

public class SAXParser : IParser
{
    private XmlTextReader reader;

    public SAXParser(Stream inputStream) {
        reader = new(inputStream);
    }
    public IList<Book> Find(FilterOptions filters)
    {
        throw new NotImplementedException();
    }
}
