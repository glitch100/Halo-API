using System;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class MapVariant : IDetail, IGuidContentIds
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MapImageUrl { get; set; }
        public Guid MapId { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}