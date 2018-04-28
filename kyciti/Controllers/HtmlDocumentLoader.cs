using System;
using System.Net;
using HtmlAgilityPack;

namespace kyciti.Controllers
{
    public interface IHtmlDocumentLoader
    {
        HtmlDocument LoaderFromUrl(string url);
    }

    // ReSharper disable once UnusedMember.Global
    public class HtmlDocumentLoader : IHtmlDocumentLoader
    {
        public HtmlDocument LoaderFromUrl(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12
                                                   | SecurityProtocolType.Ssl3;

            var securedyWebClient = new SecuredWebClient();
            string html = securedyWebClient.DownloadString(new Uri(url));
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument;
        }
    }
}