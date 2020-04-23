using System.Collections.Generic;
using SearchEngines;

namespace SearchEngineHandler
{
    public class SearchEngineResolver : ISearchEngineResolver
    {
        public IEnumerable<ISearchEngine> GetSearchEngineProviders()
        {
            return new List<ISearchEngine> {
                new GoogleSearchEngine(),
                new BingSearchEngine(),
                new YahooSearchEngine()
            };
        }
    }
}