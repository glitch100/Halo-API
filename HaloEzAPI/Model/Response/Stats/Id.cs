using System;
using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.Stats
{
    public class Id
    {
        public Guid MatchId { get; set; }
        public GameMode GameMode { get; set; }
    }
}