using System.Collections.Generic;

namespace SearchEngineModel {
    public class SearchResult {

        public SearchResult() {
            this.EngineResults = new List<EngineResult>();
        }

        public string SearchWord {get;set;}
        public List<EngineResult> EngineResults { get; set; }
        public string WordWinner {get;set;}
    }
}
