using System.Threading.Tasks;
using SearchEngineModel;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System;

namespace SearchEngines{
    public class GoogleSearchEngine : ISearchEngine
    {
        public string EngineName {get;set;}
        public string ApiKey {get;set;}

        private CustomsearchService Service;

        public GoogleSearchEngine()
        {
            this.ApiKey="AIzaSyCRXAgUzyS7NDTn42OvrrLTXisRX0AAtjw";
            this.EngineName="Google";
            this.Service = new CustomsearchService(
                new BaseClientService.Initializer {
                    ApplicationName = "SearchApi",
                    ApiKey = this.ApiKey
                }
            );
        }

        public async Task<EngineResult> Search(string keyword)
        {
            CseResource.ListRequest listRequest = this.Service.Cse.List();
            Search result;

            try {
                listRequest.Q = keyword;
                result = await listRequest.ExecuteAsync();
            } catch(Exception ex) {
                return new EngineResult {
                    EngineName = this.EngineName,
                    ResultCount = 0
                };
            }
            
            return new EngineResult {
                EngineName = this.EngineName,
                ResultCount = result.Items.Count
            };
        }
    }
}