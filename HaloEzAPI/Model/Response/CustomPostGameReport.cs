using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Interfaces;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response
{
    public class CustomPostGameReport : MatchDetails
    {
        public IEnumerable<BasePlayerStat> PlayerStats { get; set; }
        public IEnumerable<TeamStat> TeamStats { get; set; }
    }
}