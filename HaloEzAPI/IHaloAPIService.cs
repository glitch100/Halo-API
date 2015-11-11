using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Model.Response.MetaData;
using HaloEzAPI.Model.Response.Stats;

namespace HaloEzAPI
{
    public interface IHaloAPIService
    {
        //Stats
        Task<PlayerMatches> GetMatchesForPlayer(string gamerTag, GameMode gameMode, int start, int count);
        Task<ArenaPostGameReport> GetArenaPostGameCarnageReport(Guid matchId);
        Task<CampaignPostGameReport> GetCampaignPostGameCarnageReport(Guid matchId);
        Task<CustomPostGameReport> GetCustomPostGameCarnageReport(Guid matchId);
        Task<WarzonePostGameReport> GetWarzonePostGameCarnageReport(Guid matchId);
        Task<ArenaServiceRecordQueryResponse> GetArenaServiceRecords([MaxLength(32)] string[] players);
        Task<CampaignServiceRecordQueryResponse> GetCampaignServiceRecords([MaxLength(32)] string[] players);
        Task<CustomGameServiceRecordQueryResponse> GetCustomGameServiceRecords([MaxLength(32)] string[] players);
        Task<WarzoneServiceRecordQueryResponse> GetWarzoneServiceRecords([MaxLength(32)] string[] players);
        
        //MetaData
        Task<IEnumerable<CampaignMission>> GetCampaignMissions();
        Task<IEnumerable<Commendation>> GetCommendations();
        Task<IEnumerable<Enemy>> GetEnemies();
        Task<IEnumerable<FlexibleStat>> GetFlexibleStats();
        Task<IEnumerable<GameBaseVariant>> GetGameBaseVariants();
        Task<GameVariant> GetGameVariant(string id);

    }
}
