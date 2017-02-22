using System;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Campaign
{
    public class CommonContentInformation
    {
        public string Owner { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
        public DateTime PublishedUtc { get; set; }
        public int Container { get; set; }
    }
}