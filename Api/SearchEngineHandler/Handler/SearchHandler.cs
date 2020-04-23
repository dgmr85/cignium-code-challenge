using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngineModel;
using System.Linq;
using QueryParser;

namespace SearchEngineHandler
{
    public class SearchHandler : ISearchHandler
    {
        private readonly IQueryParserFactory _searchQueryFactory;
        private readonly ISearchEngineResolver _searchEngineResolver;
        public SearchHandler(IQueryParserFactory searchQueryFactory, ISearchEngineResolver searchEngineResolver) {
            _searchQueryFactory = searchQueryFactory;
            _searchEngineResolver = searchEngineResolver;
        }


        public async Task<IEnumerable<SearchResult>> ProcessSearch(string searchQuery)
        {
            var results = new List<SearchResult>();
            var parser = _searchQueryFactory.GetQueryParser();

            var searchKeyWords = parser.ParseQuery(searchQuery);

            if(!searchKeyWords.Any())
                return null;
            
            var searchEngines = _searchEngineResolver.GetSearchEngineProviders();
            SearchResult result;
            EngineResult engineResult;

            foreach(var keyWord in searchKeyWords) {
                result = new SearchResult();
                result.SearchWord = keyWord;
                    
                foreach(var searchEngine in searchEngines) {
                    engineResult = await searchEngine.Search(keyWord);
                    result.EngineResults.Add(engineResult);
                }
                results.Add(result);
            }

            return results;
        }
    }
}