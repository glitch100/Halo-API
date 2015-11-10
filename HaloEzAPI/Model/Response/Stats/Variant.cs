using System;
using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.Stats
{
    /// <summary>
    /// Used for Game and Map Variants
    /// </summary>
    public class Variant
    {
        public ResourceType ResourceType { get; set; }
        public Guid ResourceId { get; set; }
        //TODO:Refactor
        public int OwnerType { get; set; }
        public string Owner { get; set; }
    }
}