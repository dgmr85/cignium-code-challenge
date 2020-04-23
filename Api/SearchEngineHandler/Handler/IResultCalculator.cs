using System.Collections.Generic;
using SearchEngineModel;

namespace SearchEngineHandler
{
    public interface IResultCalculator
    {
         string GetWinners(IEnumerable<SearchResult> results);
    }
}