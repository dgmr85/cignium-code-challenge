namespace QueryParser
{
    public class QueryParserFactory : IQueryParserFactory
    {
        public IQueryParser GetQueryParser() {
            //custom logic for different parsers, for now returning separator parser by default
            return new SeparatorQueryParser();
        }
    }
}