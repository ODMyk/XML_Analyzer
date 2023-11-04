using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using System.Xml.Serialization;

namespace XML_Manager;

public class DOMParser : IParser
{
    private readonly XmlDocument document;

    public DOMParser()
    {
        document = new();
    }

    public bool Load(Stream inputStream)
    {
        using var reader = XmlReader.Create(inputStream, XMLValidator.Settings);
        try
        {
            document.Load(reader);
        }
        catch
        {
            return false;
        }

        return true;
    }
    public IList<Book> Find(FilterOptions filters)
    {
        IList<Book> books = new List<Book>();
        var serializer = new XmlSerializer(typeof(Book));
        if (document == null || document.DocumentElement == null) {
            return books;
        }
        foreach (XmlNode child in document.DocumentElement.ChildNodes) {
            if (serializer.Deserialize(new StringReader(child.OuterXml)) is Book book && filters.ValidateBook(book)) books.Add(book);
        }

        return books;
    }
}
