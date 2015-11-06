using System;

namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IMatchVariants
    {
        bool IsMatchOver { get; set; }
        TimeSpan TotalDuration { get; set; }
        Guid MapVariantId { get; set; }
        Guid GameVariantId { get; set; }
        Guid PlaylistId { get; set; }
        Guid MapId { get; set; }
        Guid GameBaseVariantId { get; set; }
        bool IsTeamGame { get; set; }
    }
}