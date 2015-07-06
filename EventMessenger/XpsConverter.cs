using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Packaging;

namespace EventMessenger
{
    public class XpsConverter
    {
        // Test
        public static string ExtractText(string path)
        {
            XpsDocument _xpsDocument = new XpsDocument(path, System.IO.FileAccess.Read);
            IXpsFixedDocumentSequenceReader fixedDocSeqReader
                = _xpsDocument.FixedDocumentSequenceReader;
            IXpsFixedDocumentReader _document = fixedDocSeqReader.FixedDocuments[0];
            
            IXpsFixedPageReader _page
                = _document.FixedPages[0];
            StringBuilder _currentText = new StringBuilder();
            System.Xml.XmlReader _pageContentReader = _page.XmlReader;
            if (_pageContentReader != null)
            {
                while (_pageContentReader.Read())
                {
                    if (_pageContentReader.Name == "Glyphs")
                    {
                        if (_pageContentReader.HasAttributes)
                        {
                            if (_pageContentReader.GetAttribute("UnicodeString") != null)
                            {
                                _currentText.
                                  Append(_pageContentReader.
                                  GetAttribute("UnicodeString") + "\n");
                            }
                        }
                    }
                }
            }
           return _currentText.ToString();
        }
    }
}
