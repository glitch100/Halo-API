using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace HaloEzAPI.Extensions
{
    public static class NameValueCollectionExtensions
    {
        public static Uri BuildUri(this NameValueCollection query,string root)
        {
            var collection = HttpUtility.ParseQueryString(string.Empty);

            foreach (var key in query.Cast<string>().Where(key => !string.IsNullOrEmpty(query[key])))
            {
                collection[key] = query[key];
            }

            var builder = new UriBuilder(root) { Query = collection.ToString() };
            return builder.Uri;
        }
        
    }
}