using System;

namespace SearchEngineHandler
{
    public class SearchQueryParser: ISearchQueryParser
    {
        public string[] ParseQuery(string searchQuery)
        {
            if(string.IsNullOrEmpty(searchQuery))
                return Array.Empty<string>();

            return searchQuery.Split(' ');
        }
    }
}