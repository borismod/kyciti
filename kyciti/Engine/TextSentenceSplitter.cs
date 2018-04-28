using System;
using System.IO;
using System.Reflection;
using OpenNLP.Tools.SentenceDetect;

namespace kyciti.Engine
{
    public interface ITextSentenceSplitter
    {
        string[] SplitTextToSentences(string text);
    }

    public class TextSentenceSplitter : ITextSentenceSplitter
    {
        private readonly MaximumEntropySentenceDetector _maximumEntropySentenceDetector;

        public TextSentenceSplitter()
        {
            var fullPath = Path.Combine(GetBinariesPath(), "Data", "EnglishSD.nbin");
            _maximumEntropySentenceDetector = new EnglishMaximumEntropySentenceDetector(fullPath);
        }

        public string[] SplitTextToSentences(string text)
        {
            return _maximumEntropySentenceDetector.SentenceDetect(text);
        }

        private static string GetBinariesPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}