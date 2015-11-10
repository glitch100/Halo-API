using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class FlexibleStats
    {
        public IEnumerable<StatCounter<Guid>> MedalStatCounts { get; set; } 
        public IEnumerable<StatCounter<Guid>> ImpulseStatCounts { get; set; }
        public IEnumerable<StatTimelapse> MedalTimelapses { get; set; }
        public IEnumerable<StatTimelapse> ImpulseTimelapses { get; set; } 
    }
}