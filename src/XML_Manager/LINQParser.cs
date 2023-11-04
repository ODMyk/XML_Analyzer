using System.Xml;
using System.Xml.Linq;

namespace XML_Manager;

public class LINQParser : IParser
{
    private XDocument document;

    public IList<Book> Find(FilterOptions filters)
    {
        throw new NotImplementedException();
    }

    public bool Load(Stream inputStream)
    {
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
