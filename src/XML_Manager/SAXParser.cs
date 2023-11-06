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
                if (!(reader.NodeType == XmlNodeType.Element) || !(reader.Name == "Book")) continue;
                var book = new Book();
                for (int i = 0; i < 5; ++i)
                {
                    if (!ParseBookElement(reader, book)) return false;
                }

                Books.Add(book);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool ParseBookElement(XmlReader reader, Book book) {
        do { if (!reader.Read()) return false; } while (reader.NodeType != XmlNodeType.Element);
        var name = reader.Name;
        var conditionToSkipWhile = name != "Author" ? reader.NodeType != XmlNodeType.Text : reader.NodeType != XmlNodeType.Element;
        do { if (!reader.Read()) return false; } while (conditionToSkipWhile);
        switch (name)
        {
            case "Title":
                book.Title = reader.Value;
                break;

            case "Description":
                book.Description = reader.Value;
                break;

            case "Year":
                book.Year = reader.Value;
                break;

            case "Genre":
                book.Genre = reader.Value;
                break;

            case "Author":
                if (reader.Name == "FirstName")
                {
                    do { if (!reader.Read()) return false; } while (reader.NodeType != XmlNodeType.Text);
                    book.Author.FirstName = reader.Value;
                    do { if (!reader.Read()) return false; } while (reader.NodeType != XmlNodeType.Text);
                    book.Author.LastName = reader.Value;
                    break;
                }
                do { if (!reader.Read()) return false; } while (reader.NodeType != XmlNodeType.Text);
                book.Author.LastName = reader.Value;
                do { if (!reader.Read()) return false; } while (reader.NodeType != XmlNodeType.Text);
                book.Author.FirstName = reader.Value;
                break;
        }

        return true;
    }
}
