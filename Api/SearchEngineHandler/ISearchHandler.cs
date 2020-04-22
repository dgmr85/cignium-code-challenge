using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngineModel;

namespace SearchEngineHandler {
    public interface ISearchHandler {
        Task<IEnumerable<SearchResult>> ProcessSearch(string searchQuery);
    }
}
