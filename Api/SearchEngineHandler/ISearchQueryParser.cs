namespace SearchEngineHandler
{
    public interface ISearchQueryParser
    {
         string[] ParseQuery(string searchQuery);
    }
}