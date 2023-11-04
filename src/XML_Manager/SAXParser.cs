using System.Xml;

namespace XML_Manager;

public class SAXParser : IParser
{
    private XmlReader reader;
    public IList<Book> Find(FilterOptions filters)
    {
        throw new NotImplementedException();
    }

    public bool Load(Stream inputStream)
    {
        try {
            reader = XmlReader.Create(inputStream, XMLValidator.Settings);
            return true;
        } catch {
            return false;
        }
    }
}
