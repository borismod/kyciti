using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using HtmlAgilityPack;
using kyciti.Engine;

namespace kyciti.Controllers
{
    public interface IPersonEvaluationService
    {
        Task<List<SearchEngineResult>> EvaluatePersonAsync(string personFullName, string evaluationCategory);
    }

    // ReSharper disable once UnusedMember.Global
    public class PersonEvaluationService : IPersonEvaluationService
    {
        private static readonly string[] DomainsBlacklist = { "review.easycounter.com", "twitter.com" };

        private readonly IHtmlDocumentLoader _htmlDocumentLoader;
        private readonly ISearchEngineService _searchEngineService;
        private readonly IHtmlSanitizer _htmlSanitizer;
        private readonly ITextSentenceSplitter _textSentenceSplitter;

        public PersonEvaluationService(ISearchEngineService searchEngineService, IHtmlSanitizer htmlSanitizer, ITextSentenceSplitter textSentenceSplitter, IHtmlDocumentLoader htmlDocumentLoader)
        {
            _searchEngineService = searchEngineService;
            _htmlSanitizer = htmlSanitizer;
            _textSentenceSplitter = textSentenceSplitter;
            _htmlDocumentLoader = htmlDocumentLoader;
        }

        public async Task<List<SearchEngineResult>> EvaluatePersonAsync(string personFullName, string evaluationCategory)
        {
            var searchEngineResults = await _searchEngineService.Search(personFullName, evaluationCategory);
            return searchEngineResults
                .Where(NotInDomainBlacklist)
                .Where(r => HasRelevantSentences(personFullName, evaluationCategory, r)).ToList();
        }

        private bool NotInDomainBlacklist(SearchEngineResult searchEngineResult)
        {
            var host = new Uri(searchEngineResult.Url).Host;
            var notInDomainBlacklist = !DomainsBlacklist.Contains(host);
            return notInDomainBlacklist;
        }

        private bool HasRelevantSentences(string personFullName, string evaluationCategory,
            SearchEngineResult searchEngineResult)
        {
            HtmlDocument htmlDocument = _htmlDocumentLoader.LoadFromUrl(searchEngineResult.Url);
            string text = _htmlSanitizer.SanitizeHtmlDocument(htmlDocument);
            string[] sentences = _textSentenceSplitter.SplitTextToSentences(text);
            bool hasRelevantSentences = sentences.Any(s => s.Contains(personFullName) && s.Contains(evaluationCategory));
            return hasRelevantSentences;
        }
    }
}