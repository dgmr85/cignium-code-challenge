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
        private readonly IResultCalculator _resultCalculator;

        public SearchEngineController(ILogger<SearchEngineController> logger,
                ISearchHandler searchHandler,
                IResultCalculator resultCalculator)
        {
            _logger = logger;
            _searchHandler = searchHandler;
            _resultCalculator = resultCalculator;
        }

        [HttpPost]
        [Route("Search")] 
        public async Task<ActionResult> Search([FromBody] QueryBody query)
        {
            var result = await _searchHandler.ProcessSearch(query.SearchQuery);
            var winner = _resultCalculator.GetWinners(result);

            if(result == null)
                return NotFound();
            
            return Ok(new {
                result=result,
                finalWinner=winner
            });
        }
    }
}
