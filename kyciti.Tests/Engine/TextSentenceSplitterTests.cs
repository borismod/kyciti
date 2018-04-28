using FluentAssertions;
using kyciti.Engine;
using NUnit.Framework;

namespace kyciti.Tests.Engine
{
    [TestFixture]
    public class TextSentenceSplitterTests
    {
        [Test]
        public void SplitTextToSentences_TextWithTwoSentences_SplitToTwoSentences()
        {
            // Arrange
            var textSentenceSplitter = new TextSentenceSplitter();

            // Act
            var sentences = textSentenceSplitter.SplitTextToSentences("Hi! I'm three sentences.  Are you?");

            // Assert
            sentences.Should().HaveCount(3);
            sentences[0].Should().Be("Hi!");
            sentences[1].Should().Be("I'm three sentences.");
            sentences[2].Should().Be("Are you?");
        }
    }
}