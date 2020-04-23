using System.Threading.Tasks;
using SearchEngineModel;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System;

namespace SearchEngines{
    public class GoogleSearchEngine : BaseSearchEngine
    {
        private CustomsearchService Service;

        public GoogleSearchEngine():base("Google")
        {
            ApiKey="AIzaSyCRXAgUzyS7NDTn42OvrrLTXisRX0AAtjw";
            this.Service = new CustomsearchService(
                new BaseClientService.Initializer {
                    ApplicationName = "SearchApi",
                    ApiKey = ApiKey
                }
            );
        }

        public override async Task<EngineResult> Search(string keyword)
        {
            CseResource.ListRequest listRequest = this.Service.Cse.List();
            Search result;

            try {
                listRequest.Q = keyword;
                result = await listRequest.ExecuteAsync();
            } catch(Exception ex) {
                return new EngineResult {
                    EngineName = base.EngineName,
                    ResultCount = 0
                };
            }
            
            return new EngineResult {
                EngineName = base.EngineName,
                ResultCount = result.Items.Count
            };
        }
    }
}