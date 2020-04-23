using System;
using System.Linq;

namespace QueryParser
{
    public class SeparatorQueryParser: IQueryParser
    {
        public string[] ParseQuery(string searchQuery)
        {
            var result = Array.Empty<string>();

            if(string.IsNullOrEmpty(searchQuery))
                return result;

            if(searchQuery.Contains(';'))
                result = searchQuery.Split(';');
            
            if(searchQuery.Contains(' '))
                result = searchQuery.Split(' ');

            if(result.Any())
                result = result.Select(w=>w.Trim()).ToArray();
            else {
                result = new string[1];
                result[0] = searchQuery;
            }

            return result;
        }
    }
}