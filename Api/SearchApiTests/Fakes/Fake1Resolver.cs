using System;
using System.Collections.Generic;
using QueryParser;
using SearchEngineHandler;
using SearchEngines;

namespace SearchApiTests
{
    public class Fake1Resolver : ISearchEngineResolver
    {
        public IEnumerable<ISearchEngine> GetSearchEngineProviders()
        {
            return new List<ISearchEngine> {
                new GoogleSearchEngine()
            };
        }
    }
}