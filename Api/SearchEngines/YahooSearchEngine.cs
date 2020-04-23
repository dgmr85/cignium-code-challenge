using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using SearchEngineModel;
using Newtonsoft.Json.Linq;

namespace SearchEngines
{
    public class YahooSearchEngine : BaseSearchEngine
    {
        public YahooSearchEngine():base("Yahoo")
        {
            base.UriBase = "http://search.yahooapis.com/WebSearchService/V1/webSearch?appid=YahooDemo&query={0}";
        }

        public override async Task<EngineResult> Search(string keyword)
        {
            var uriQuery = string.Format(base.UriBase,keyword);
            WebRequest request = HttpWebRequest.Create(uriQuery);

            //code for yahoo api should go here
            
            return new EngineResult{
                EngineName = base.EngineName,
                ResultCount = 0
            };
        }
    }
}