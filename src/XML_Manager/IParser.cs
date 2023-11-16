using System.Xml;

namespace XML_Manager;

public interface IParser
{
    public bool Load(Stream inputStream, XmlReaderSettings settings);
    public IList<Book> Find(FilterOptions filters);
}
