using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE20Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }
            this.webBrowser1.DocumentCompleted += new
            WebBrowserDocumentCompletedEventHandler(this.WebBrowser1__DocumentCompleted);

        }
        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            


            HtmlElement h1Element = webBrowser.Document.GetElementsByTagName("h1")[0];
            if (h1Element != null)
                h1Element.InnerText = "My UFO Page";

            
            HtmlElement h2Element1 = webBrowser.Document.GetElementsByTagName("h2")[0];
            if (h2Element1 != null)
                h2Element1.InnerText = "My UFO Info";

           
            HtmlElement h2Element2 = webBrowser.Document.GetElementsByTagName("h2")[1];
            if (h2Element2 != null)
                h2Element2.InnerText = "My UFO Pictures";

           
            HtmlElement h2Element3 = webBrowser.Document.GetElementsByTagName("h2")[2];
            if (h2Element3 != null)
                h2Element3.InnerText = "";

            
            HtmlElement bodyElement = webBrowser.Document.Body;
            if (bodyElement != null)
            {
                
                bodyElement.Style = "font-family: sans-serif;";

                
                bodyElement.Style += "color: #FF0000;";
            }

            
            HtmlElement firstParagraph = webBrowser.Document.GetElementsByTagName("p")[0];
            if (firstParagraph != null)
            {
            
                firstParagraph.InnerHtml = "Report your UFO sightings here: <a href='http://www.nuforc.org'>http://www.nuforc.org</a>";

                
                firstParagraph.Style = "color: green; font-weight: bold; font-size: 2em; text-transform: uppercase; text-shadow: 3px 2px #A44;";
            }

            
            HtmlElement secondParagraph = webBrowser.Document.GetElementsByTagName("p")[1];
            if (secondParagraph != null)
                secondParagraph.InnerText = "";

      
            HtmlElement thirdParagraph = webBrowser.Document.GetElementsByTagName("p")[2];
            if (thirdParagraph != null)
            {
                HtmlElement imgElement = webBrowser.Document.CreateElement("img");
                imgElement.SetAttribute("src", "https://a57.foxnews.com/static.foxnews.com/foxnews.com/content/uploads/2020/04/931/524/UFO-iStock.jpg?ve=1&tl=1");
                thirdParagraph.InsertAdjacentElement(HtmlElementInsertionOrientation.BeforeBegin, imgElement);
            }

            HtmlElement footerElement = webBrowser.Document.CreateElement("footer");
            footerElement.InnerHtml = "&copy; " + DateTime.Now.Year + " Your Name";
            webBrowser.Document.Body.AppendChild(footerElement);
        }

    }

}

