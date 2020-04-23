using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using SearchEngineModel;
using Newtonsoft.Json.Linq;

namespace SearchEngines {
    public class BingSearchEngine : BaseSearchEngine
    {
        public BingSearchEngine():base("Bing") {
            base.ApiKey = "195739954a5e4bbcadd2fb170fe09ae8";
            base.UriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";
        }

        public override async Task<EngineResult> Search(string keyword)
        {
            var uriQuery = string.Concat(base.UriBase,"?q=",Uri.EscapeDataString(keyword));
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = base.ApiKey;

            JObject result;

            try {
                using(HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync())) {
                    string json = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
                    result = JObject.Parse(json);
                }
            } catch(Exception ex) {
                return new EngineResult{
                    EngineName = base.EngineName,
                    ResultCount = 0
                };
            }

            return new EngineResult{
                    EngineName = base.EngineName,
                    ResultCount = int.Parse(result["webPages"]["totalEstimatedMatches"].ToString())
                };
        }
    }
}