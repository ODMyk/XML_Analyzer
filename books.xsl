<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" />
<xsl:template match="/">
  <html>
  <body>
  <h2>Books list</h2>
    <table border="1">
      <tr bgcolor="#fff">
        <th>Title</th>
        <th>Author</th>
        <th>Year</th>
        <th>Genre</th>
        <th>Description</th>
      </tr>
      <xsl:for-each select="//Book">
      <tr>
        <td><xsl:value-of select="Title"/></td>
        <td><xsl:value-of select="Author"/></td>
        <td><xsl:value-of select="Year"/></td>
        <td><xsl:value-of select="Genre"/></td>
        <td><xsl:value-of select="Description"/></td>
      </tr>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>