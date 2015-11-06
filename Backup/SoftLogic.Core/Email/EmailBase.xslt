<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <Email>
      <MessageSubject>
        <xsl:apply-templates select="//MessageSubject"/>
      </MessageSubject>
      <MessageBody>
        <xsl:apply-templates select="//MessageBody"/>
      </MessageBody>
    </Email>
  </xsl:template>
</xsl:stylesheet>