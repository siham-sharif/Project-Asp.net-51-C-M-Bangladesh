using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Pdf;
using System.IO;
using System.Net;
using Aspose.Pdf.Generator;
using Aspose.Pdf.Facades;
using System.Text;

namespace WebO.Models
{
    public class WebPageToPDF
    {
        public void WebPDF( string  webPage)
        {
            // The address of the web URL which you need to convert into PDF format
            string WebUrl = webPage;
            // create a Web Request object to connect to remote URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WebUrl);
            // set the Web Request timeout
            request.Timeout = 10000;     // 10 secs

            // Retrieve request info headers
            HttpWebResponse localWebResponse = (HttpWebResponse)request.GetResponse();
            // Windows default Code Page  (Include System.Text namespace in project)
            Encoding encoding = Encoding.GetEncoding(1252);
            // Read the contents of into StreamReader object
            StreamReader localResponseStream = new StreamReader(localWebResponse.GetResponseStream(), encoding);

            // Instantiate an object PDF class
            Aspose.Pdf.Generator.Pdf pdf = new Aspose.Pdf.Generator.Pdf();

            // add the section to PDF document sections collection
            Aspose.Pdf.Generator.Section section = pdf.Sections.Add();

            //Create text paragraphs containing HTML text
            Aspose.Pdf.Generator.Text text2 = new Aspose.Pdf.Generator.Text(section, localResponseStream.ReadToEnd());

            // enable the property to display HTML contents within their own formatting
            text2.IsHtmlTagSupported = true;

            // Add the text object containing HTML contents to PD Sections
            section.Paragraphs.Add(text2);

            // Specify the URL which serves as images database
            pdf.HtmlInfo.ImgUrl = "http://localhost:3610/center/Images/";
            pdf.HtmlInfo.ExternalResourcesBasePath = "http://localhost:3610/center/site.css";
            //Save the pdf document
            pdf.Save("D:/HtmlToPdf.pdf");

            localWebResponse.Close();
            localResponseStream.Close();
        }
    }
}