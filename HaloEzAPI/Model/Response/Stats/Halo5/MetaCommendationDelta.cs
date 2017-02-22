using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    public class MetaCommendationDelta
    {
        public Guid Id { get; set; }
        public IEnumerable<RawGuid> PreviousMetRequirements { get; set; }
        public IEnumerable<RawGuid> MetRequirements { get; set; } 
    }
}