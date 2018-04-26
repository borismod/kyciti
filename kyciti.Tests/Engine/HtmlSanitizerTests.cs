using FluentAssertions;
using HtmlAgilityPack;
using kyciti.Engine;
using NUnit.Framework;

namespace kyciti.Tests.Engine
{
    [TestFixture]
    public class HtmlSanitizerTests
    {
        [Test]
        public void SanitizeHtml_ExistingUrl_DoesNotContainHtmlTags()
        {
            // Arrange
            var htmlWeb = new HtmlWeb();
            var document = htmlWeb.Load(@"https://en.wikipedia.org/wiki/Strategy_pattern");

            // Act
            var htmlSanitizer = new HtmlSanitizer();
            var cleanText = htmlSanitizer.SanitizeHtmlDocument(document);

            // Assert
            cleanText.Should()
                .NotContain(@"<img")
                .And.NotContain(@"<div")
                .And.NotContain(@"<!DOCTYPE html>")
                .And.NotContain(@"document.documentElement.className");
        }
    }
}