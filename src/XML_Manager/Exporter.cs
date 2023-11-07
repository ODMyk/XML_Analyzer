using System.Xml.Xsl;

namespace XML_Manager;
public static class Exporter
{
    private static readonly XslCompiledTransform compiler;

    static Exporter()
    {
        compiler = new();
        compiler.Load("/storage/emulated/0/documents/books.xsl"); // should not be hardcoded
    }

    public static void Export(string fromPath, string toPath)
    {
        compiler.Transform(fromPath, toPath);
    }
}
