using System.Collections.Generic;

namespace SearchEngineModel {
    public class SearchResult {

        public SearchResult() {
            this.EngineResult = new List<EngineResult>();
        }

        public string SearchWord {get;set;}
        public List<EngineResult> EngineResult { get; set; }
    }
}
