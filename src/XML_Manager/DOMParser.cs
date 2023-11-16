using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Linq;

namespace XML_Manager;

public class DOMParser : Parser
{
    public DOMParser()
    {
        Books = new List<Book>();
    }

    public override bool Load(Stream inputStream)
    {
        Books.Clear();
        var document = new XmlDocument();
        using var reader = XmlReader.Create(inputStream, XMLValidator.Settings);
        try
        {
            document.Load(reader);
            if (document == null || document.DocumentElement == null)
            {
                return true;
            }
            var serializer = new XmlSerializer(typeof(Book));
            foreach (XmlNode child in document.DocumentElement.ChildNodes)
            {
                if (serializer.Deserialize(new StringReader(child.OuterXml)) is Book book)
                {
                    Books.Add(book);
                }
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
}
