using System.Collections.Generic;
using SearchEngines;

namespace SearchEngineHandler
{
    public interface ISearchEngineResolver
    {
         IEnumerable<ISearchEngine> GetSearchEngineProviders();
    }
}