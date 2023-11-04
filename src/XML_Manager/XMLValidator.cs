using System.Xml;
using System.Xml.Schema;

namespace XML_Manager;

public static class XMLValidator
{
    public static XmlReaderSettings Settings { get; }

    static XMLValidator()
    {
        var schema = new XmlSchemaSet();
        schema.Add("", "/storage/emulated/0/documents/books.xsd");

        Settings = new XmlReaderSettings
        {
            Schemas = schema
        };
        Settings.ValidationEventHandler += (object? sender, ValidationEventArgs e) =>
        {
            if (e.Severity == XmlSeverityType.Error) throw new Exception();
        };
        Settings.ValidationType = ValidationType.Schema;
    }
}
