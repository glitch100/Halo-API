using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
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
        Task<IEnumerable<Impulse>> GetImpulses();
        Task<MapVariant> GetMapVariant(string id);
        Task<IEnumerable<Map>> GetMaps();
        Task<IEnumerable<Medal>> GetMedals();
        Task<IEnumerable<Playlist>> GetPlaylists();
        Task<RequisitionPack> GetRequisitionPack(Guid id);
        Task<RequisitionPack> GetRequisition(Guid id);
        Task<IEnumerable<Skull>> GetSkulls();
        Task<IEnumerable<SpartanRank>> GetSpartanRanks();
        Task<IEnumerable<TeamColor>> GetTeamColours();
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<IEnumerable<Weapon>> GetWeapons();
        Task<Image> GetProfileEmblem(string gamerTag, int size = 256);
        Task<Image> GetSpartanImage(string gamerTag, int size = 256, CropType cropType = CropType.Full);
    }
}
