using System;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class GameVariant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? GameBaseVariantId { get; set; }
        public string IconUrl { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}