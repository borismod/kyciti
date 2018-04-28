using HtmlAgilityPack;

namespace kyciti.Engine
{
    public class SentencesExtractor
    {
        private readonly IHtmlSanitizer _htmlSanitizer;
        private readonly ITextSentenceSplitter _textSentenceSplitter;

        public SentencesExtractor(IHtmlSanitizer htmlSanitizer, ITextSentenceSplitter textSentenceSplitter)
        {
            _htmlSanitizer = htmlSanitizer;
            _textSentenceSplitter = textSentenceSplitter;
        }

        public string[] ExtractSentences(string url)
        {
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);

            var text = _htmlSanitizer.SanitizeHtmlDocument(htmlDocument);

            return _textSentenceSplitter.SplitTextToSentences(text);
        }
    }
}