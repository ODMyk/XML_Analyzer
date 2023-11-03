using System.Xml.Linq;

namespace XML_Manager;

public class LINQParser : IParser
{
    private XDocument document;

    public LINQParser(Stream inputStream) {
        document = XDocument.Load(inputStream);
    }
    public IList<Book> Find(FilterOptions filters)
    {
        throw new NotImplementedException();
    }
}
