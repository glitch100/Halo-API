using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.UGC
{
    public class UGCSearchResult<T> where T : UGCBase
    {
        public IEnumerable<T> Results { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public int TotalCount { get; set; }
    }
}