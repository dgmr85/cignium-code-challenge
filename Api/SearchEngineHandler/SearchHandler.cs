using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngineModel;
using System.Linq;

namespace SearchEngineHandler
{
    public class SearchHandler : ISearchHandler
    {
        private readonly ISearchQueryParser _searchQueryParser;
        private readonly ISearchEngineResolver _searchEngineResolver;
        public SearchHandler(ISearchQueryParser searchQueryParser, ISearchEngineResolver searchEngineResolver) {
            _searchQueryParser = searchQueryParser;
            _searchEngineResolver = searchEngineResolver;
        }


        public async Task<IEnumerable<SearchResult>> ProcessSearch(string searchQuery)
        {
            var results = new List<SearchResult>();

            var searchKeyWords = _searchQueryParser.ParseQuery(searchQuery);

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
                    result.EngineResult.Add(engineResult);
                }
                results.Add(result);
            }

            return results;
        }
    }
}