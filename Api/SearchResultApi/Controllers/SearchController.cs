using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchEngineModel;
using SearchEngineHandler;
using Microsoft.AspNetCore.Cors;

namespace SearchResultApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchEngineController : ControllerBase
    {
        private readonly ILogger<SearchEngineController> _logger;
        private readonly ISearchHandler _searchHandler;

        public SearchEngineController(ILogger<SearchEngineController> logger,
                ISearchHandler searchHandler)
        {
            _logger = logger;
            _searchHandler = searchHandler;
        }

        [HttpPost]
        [Route("Search")] 
        public async Task<ActionResult> Search([FromBody] QueryBody query)
        {
            var result = await _searchHandler.ProcessSearch(query.SearchQuery);

            if(result == null)
                return NotFound();
            
            return Ok(new {
                result=result
            });
        }
    }
}
