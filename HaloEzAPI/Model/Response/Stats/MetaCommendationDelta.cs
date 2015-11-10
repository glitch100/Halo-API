using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class MetaCommendationDelta
    {
        public Guid Id { get; set; }
        public IEnumerable<MetRequirement> PreviousMetRequirements { get; set; } 
        public IEnumerable<MetRequirement> MetRequirements { get; set; } 
    }
}