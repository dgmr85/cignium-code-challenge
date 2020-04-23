using QueryParser;
using SearchEngineHandler;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace SearchApiTests
{
    public class SearchEnginHandlerTests
    {
        private ISearchHandler _fakeSearchHandler;

        [Fact]
        public async Task SearchEmptyString_Returns_Null() {
            _fakeSearchHandler = new SearchHandler(new QueryParserFactory(),null);
            var result = await _fakeSearchHandler.ProcessSearch("");

            Assert.Equal(result,null);
        }

        [Fact]
        public async Task SearchEmptyProviders_1KeyWord_Returns_1Result() {
            _fakeSearchHandler = new SearchHandler(new QueryParserFactory(),new FakeEmptyResolver());
            var result = await _fakeSearchHandler.ProcessSearch("something");

            Assert.Equal(result.Count(),1);
        }

        [Fact]
        public async Task Search1Provider_1KeyWord_Returns_1Result() {
            _fakeSearchHandler = new SearchHandler(new QueryParserFactory(),new Fake1Resolver());
            var result = await _fakeSearchHandler.ProcessSearch("something");

            Assert.Equal(result.First().EngineResults.Count(),1);
        }
    }
}