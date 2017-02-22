using System;
using HaloEzAPI.Abstraction.Enum.Halo5;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    /// <summary>
    /// Used for Game and Map Variants
    /// </summary>
    public class Variant
    {
        public ResourceType ResourceType { get; set; }
        public Guid ResourceId { get; set; }
        public int OwnerType { get; set; }
        public string Owner { get; set; }
    }
}