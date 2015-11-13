using System;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class TeamColor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string IconUrl { get; set; }
        public uint Id { get; set; }
        public Guid ContentId { get; set; }
    }
}