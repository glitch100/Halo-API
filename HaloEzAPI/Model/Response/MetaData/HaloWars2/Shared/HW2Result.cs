using System.Collections.Generic;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared
{
    public class HW2Result<T> where T : class 
    {
        public Paging Paging { get; set; }
        public IEnumerable<T> ContentItems { get; set; } 
    }
}