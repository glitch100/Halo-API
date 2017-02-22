using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData.Halo5
{
    public class Map : IGuidContentIds, IDetail
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<GameMode> SupportedGameModes { get; set; }
        public string ImageUrl { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}