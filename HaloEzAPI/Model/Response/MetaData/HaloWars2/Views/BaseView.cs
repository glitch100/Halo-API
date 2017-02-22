using System;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Campaign;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Views
{
    public class BaseView
    {
        public string Status { get; set; }
        public CommonContentInformation Common { get; set; }
        public Guid Identity { get; set; }
        public string Title { get; set; }
    }
}