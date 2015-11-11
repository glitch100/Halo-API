using System;
using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Enemy
    {
        public Faction Faction { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LargeIconImageUrl { get; set; }
        public string SmallIconImageUrl { get; set; }
        public uint Id { get; set; }
        public Guid ContentId { get; set; }
    }
}