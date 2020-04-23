using System;
using System.Collections.Generic;
using QueryParser;
using SearchEngineHandler;
using SearchEngines;

namespace SearchApiTests
{
    public class FakeEmptyResolver : ISearchEngineResolver
    {
        public IEnumerable<ISearchEngine> GetSearchEngineProviders()
        {
            return new List<ISearchEngine>();
        }
    }
}