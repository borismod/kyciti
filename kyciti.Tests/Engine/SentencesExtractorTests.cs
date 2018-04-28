using FluentAssertions;
using kyciti.Engine;
using NUnit.Framework;

namespace kyciti.Tests.Engine
{
    [TestFixture]
    public class SentencesExtractorTests
    {
        [Test]
        public void ExtractSentences_RealUrl_SentencesExtracted()
        {
            var sentencesExtractor = new SentencesExtractor(new HtmlSanitizer(), new TextSentenceSplitter());

            var extractSentences = sentencesExtractor.ExtractSentences(@"https://arxiv.org/abs/1609.02031");

            extractSentences.Should().HaveCount(23);
        }
    }
}