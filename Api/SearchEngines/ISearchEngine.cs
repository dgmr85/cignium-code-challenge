using System.Threading.Tasks;
using SearchEngineModel;
using System.Collections.Generic;

namespace SearchEngines
{
    public interface ISearchEngine
    {
        string EngineName {get;set;}
        string ApiKey { get; set; }

        Task<EngineResult> Search(string keyword);
    }
}