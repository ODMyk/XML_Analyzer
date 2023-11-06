using System.Xml;

namespace XML_Manager;

public class SAXParser : IParser
{
    private readonly IList<Book> Books;

    public SAXParser()
    {
        Books = new List<Book>();
    }
    public IList<Book> Find(FilterOptions filters)
    {
        return Books.Where(filters.ValidateBook).ToList();
    }

    public bool Load(Stream inputStream)
    {
        Books.Clear();
        try
        {
            var reader = XmlReader.Create(inputStream, XMLValidator.Settings);
            while (reader.Read())
            {
                if (!(reader.NodeType == XmlNodeType.Element && reader.Name == "Book")) continue;
                var book = new Book();
                SkipToText(reader);
                book.Title = reader.Value;
                SkipToText(reader);
                book.Description = reader.Value;
                SkipToText(reader);
                book.Year = reader.Value;
                SkipToText(reader);
                book.Genre = reader.Value;
                SkipToText(reader);
                book.Author.FirstName = reader.Value;
                SkipToText(reader);
                book.Author.LastName = reader.Value;

                Books.Add(book);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void SkipToText(XmlReader reader)
    {
        do { if (!reader.Read()) throw new Exception(); } while (reader.NodeType != XmlNodeType.Text);
    }
}
