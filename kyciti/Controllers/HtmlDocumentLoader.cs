using System;
using System.Net;
using HtmlAgilityPack;
using log4net;

namespace kyciti.Controllers
{
    public interface IHtmlDocumentLoader
    {
        HtmlDocument LoadFromUrl(string url);
    }

    // ReSharper disable once UnusedMember.Global
    public class HtmlDocumentLoader : IHtmlDocumentLoader
    {
        private readonly ILog _log;
        private readonly SecuredWebClient _securedyWebClient = new SecuredWebClient();

        public HtmlDocumentLoader(ILog log)
        {
            _log = log;
        }

        public HtmlDocument LoadFromUrl(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12
                                                   | SecurityProtocolType.Ssl3;

            try
            {
                string html = _securedyWebClient.DownloadString(new Uri(url));
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                return htmlDocument;
            }
            catch (WebException webException)
            {
                _log.Error($"Failed to load HTML from {url}", webException);
                return null;
            }
        }
    }
}