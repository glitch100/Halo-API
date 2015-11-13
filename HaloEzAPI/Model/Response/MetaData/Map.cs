using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Map
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<GameMode> SupportedGameModes { get; set; }
        public string ImageUrl { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}