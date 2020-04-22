using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngineModel;
using Newtonsoft.Json.Linq;

namespace SearchEngines {
    public class BingSearchEngine : ISearchEngine
    {
        public string EngineName {get;set;}
        public string ApiKey {get;set;}

        private const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";

        public BingSearchEngine() {
            this.EngineName = "Bing";
            this.ApiKey = "195739954a5e4bbcadd2fb170fe09ae8";
        }

        public async Task<EngineResult> Search(string keyword)
        {
            var uriQuery = string.Concat(uriBase,"?q=",Uri.EscapeDataString(keyword));
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = this.ApiKey;

            JObject result;

            try {
                HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
                string json = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
                result = JObject.Parse(json);
            } catch(Exception ex) {
                return new EngineResult{
                    EngineName = this.EngineName,
                    ResultCount = 0
                };
            }

            return new EngineResult{
                    EngineName = this.EngineName,
                    ResultCount = int.Parse(result["webPages"]["totalEstimatedMatches"].ToString())
                };
        }
    }
}