using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace kyciti.Engine
{
    public interface IHtmlSanitizer
    {
        string SanitizeHtmlDocument(HtmlDocument document);
    }

    public class HtmlSanitizer : IHtmlSanitizer
    {
        private static readonly string[] BlackListNodeNames = {"script", "style", "#comment"};
        private static readonly string[] WhiteListNodeNames = {"strong", "em", "u"};

        public string SanitizeHtmlDocument(HtmlDocument document)
        {
            RemoveBlackListNodes(document);

            LeaveWhiteListNodes(document);

            return document.DocumentNode.InnerHtml;
        }

        private static void LeaveWhiteListNodes(HtmlDocument document)
        {
            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (!WhiteListNodeNames.Contains(node.Name) && node.Name != "#text")
                {
                    var childNodes = node.SelectNodes("./*|./text()");

                    if (childNodes != null)
                        foreach (var child in childNodes)
                        {
                            nodes.Enqueue(child);
                            parentNode.InsertBefore(child, node);
                        }

                    parentNode.RemoveChild(node);
                }
            }
        }

        private static void RemoveBlackListNodes(HtmlDocument document)
        {
            document.DocumentNode.Descendants()
                .Where(n => BlackListNodeNames.Contains(n.Name))
                .ToList()
                .ForEach(n => n.Remove());
        }
    }
}