using System.Threading.Tasks;
using SearchEngineModel;
using System.Collections.Generic;

namespace SearchEngines
{
    public interface ISearchEngine
    {
        Task<EngineResult> Search(string keyword);
    }
}