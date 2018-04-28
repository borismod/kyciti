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

            SaveResourceToFile(fullPath);

            _maximumEntropySentenceDetector = new EnglishMaximumEntropySentenceDetector(fullPath);
        }

        public string[] SplitTextToSentences(string text)
        {
            return _maximumEntropySentenceDetector.SentenceDetect(text);
        }

        private static void SaveResourceToFile(string fullPath)
        {
            var assembly = typeof(TextSentenceSplitter).Assembly;
            var resourceName = "kyciti.Data.EnglishSD.nbin";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (var fileStream = File.Create(fullPath))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
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