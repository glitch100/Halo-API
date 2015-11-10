using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class WarzoneStat : PlayerMatchBreakdown
    {
        public int TotalPiesEarned { get; set; }
        public IEnumerable<ScenarioStat> ScenarioStats { get; set; } 
    }
}