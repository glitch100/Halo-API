using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Model.Response;

namespace HaloEzAPI
{
    public interface IHaloAPIService
    {
        Task<PlayerMatches> GetMatchesForPlayer(string gamerTag, GameMode gameMode, int start, int count);
        Task<ArenaPostGameReport> GetArenaPostGameCarnageReport(Guid matchId);
        Task<CampaignPostGameReport> GetCampaignPostGameCarnageReport(Guid matchId);
        Task<CustomPostGameReport> GetCustomPostGameCarnageReport(Guid matchId);
        Task<WarzonePostGameReport> GetWarzonePostGameCarnageReport(Guid matchId);
        Task<ArenaServiceRecordQueryResponse> GetArenaServiceRecords([MaxLength(32)] string[] players);
        Task<CampaignServiceRecordQueryResponse> GetCampaignServiceRecords([MaxLength(32)] string[] players);
        Task<CustomGameServiceRecordQueryResponse> GetCustomGameServiceRecords([MaxLength(32)] string[] players);
    }
}
