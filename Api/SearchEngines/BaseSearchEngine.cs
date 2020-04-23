using System.Threading.Tasks;
using SearchEngineModel;

namespace SearchEngines
{
    public abstract class BaseSearchEngine : ISearchEngine
    {
        protected string EngineName { get; set; }
        protected string ApiKey { get; set; }
        protected string UriBase  { get; set; }

        public BaseSearchEngine(string engineName) {
            this.EngineName = engineName;
        }

        public virtual Task<EngineResult> Search(string keyword)
        {
            throw new System.NotImplementedException();
        }
    }
}