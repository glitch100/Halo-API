using System;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class MapVariant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MapImageUrl { get; set; }
        public Guid MapId { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}