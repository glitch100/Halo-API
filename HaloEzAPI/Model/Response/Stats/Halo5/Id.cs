using System;
using HaloEzAPI.Abstraction.Enum.Halo5;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    public class Id
    {
        public Guid MatchId { get; set; }
        public GameMode GameMode { get; set; }
    }
}