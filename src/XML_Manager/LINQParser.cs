using System.Xml;
using System.Xml.Linq;

namespace XML_Manager;

public class LINQParser : Parser
{
    public LINQParser()
    {
        Books = new List<Book>();
    }

    public override bool Load(Stream inputStream, XmlReaderSettings settings)
    {
        XDocument document;
        using var reader = XmlReader.Create(inputStream, settings);
        try
        {
            Books.Clear();
            document = XDocument.Load(reader);
            if (document == null)
            {
                return true;
            }
            var result = from book in document.Descendants("Book")
                         select
            new Book
            {
                Title = book.Element("Title")?.Value ?? "",
                Description = book.Element("Description")?.Value ?? "",
                Genre = book.Element("Genre")?.Value ?? "",
                Year = book.Element("Year")?.Value ?? "",
                Author = new Book.BookAuthor
                {
                    FirstName = book.Element("Author")?.Element("FirstName")?.Value ?? "",
                    LastName = book.Element("Author")?.Element("LastName")?.Value ?? ""
                }
            };
            foreach (var book in result)
            {
                Books.Add(book);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
