using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class GameBaseVariant
    {
        public string Name { get; set; }
        public string InternalName { get; set; }
        public string IconUrl { get; set; }
        public IEnumerable<GameMode> SupportedGameModes { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}