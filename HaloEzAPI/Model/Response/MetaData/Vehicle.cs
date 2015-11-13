using System;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Vehicle
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LargeIconImageUrl { get; set; }
        public string SmallIconImageUrl { get; set; }
        public bool IsUsableByPlayer { get; set; }
        public uint Id { get; set; }
        public Guid ContentId { get; set; }
    }
}