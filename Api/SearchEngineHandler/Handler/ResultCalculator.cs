using System.Collections.Generic;
using SearchEngineModel;
using System.Linq;

namespace SearchEngineHandler
{
    public class ResultCalculator : IResultCalculator
    {
        public string GetWinners(IEnumerable<SearchResult> results)
        {
            var summary = new Dictionary<string, int>();

            foreach(var result in results) {
                result.EngineResults.Sort((a,b) => (b.ResultCount.CompareTo(a.ResultCount)));
                result.WordWinner = result.EngineResults.First().EngineName;
                if(summary.Any(d=>d.Key==result.WordWinner)) {
                    var t = summary.Count(d=>d.Key==result.WordWinner);
                    summary[result.WordWinner] = t++;
                } else {
                    summary[result.WordWinner] = 1;
                }
            }

            return summary.OrderByDescending(e=>e.Value).First().Key;
        }
    }
}