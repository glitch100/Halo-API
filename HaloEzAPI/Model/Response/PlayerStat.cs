using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class PlayerStat
    {
        public XpInfo XpInfo { get; set; }
        public CSR PreviousCsr { get; set; }
        public CSR CurrentCsr { get; set; }
        public int MeasurementMatchesLeft { get; set; }
        public IEnumerable<RewardSetObject> RewardSets { get; set; }
        public IEnumerable<KillDetail> KilledOpponentDetails { get; set; }
        public IEnumerable<KillDetail> KilledByOpponentDetails { get; set; }
        public FlexibleStats FlexibleStats { get; set; }
        public CreditsEarned CreditsEarned { get; set; }
        public IEnumerable<MetaCommendationDelta> MetaCommendationDeltas { get; set; }
        public ProgressiveCommendationDelta ProgressiveCommendationDeltas { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public int Rank { get; set; }
        public bool DNF { get; set; }
        public string AvgLifeTimeOfPlayer { get; set; }
        public int TotalKills { get; set; }
        public int TotalHeadshots { get; set; }
        public double TotalWeaponDamage { get; set; }
        public int TotalShotsFired { get; set; }
        public int TotalShotsLanded { get; set; }
        public WeaponKillDetail WeaponWithMostKills { get; set; }
        public int TotalMeleeKills { get; set; }
        public double TotalMeleeDamage { get; set; }
        public int TotalAssassinations { get; set; }
        public int TotalGroundPoundKills { get; set; }
        public double TotalGroundPoundDamage { get; set; }
        public int TotalShoulderBashKills { get; set; }
        public double TotalShoulderBashDamage { get; set; }
        public double TotalGrenadeDamage { get; set; }
        public int TotalPowerWeaponKills { get; set; }
        public double TotalPowerWeaponDamage { get; set; }
        public int TotalPowerWeaponGrabs { get; set; }
        public DateTime TotalPowerWeaponPossesionTime { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalAssists { get; set; }
        public int TotalGamesCompleted { get; set; }
        public int TotalGamesWon { get; set; }
        public int TotalGamesLost { get; set; }
        public int TotalGamesTied { get; set; }
        public TimeSpan TotalTimePlayed { get; set; }
        public int TotalGrenadeKills { get; set; }
        public MedalStatCounter MedalAwards { get; set; }
        public IEnumerable<Kill> DestroyedEnemyVehicles { get; set; }
        public IEnumerable<Kill> EnemyKills { get; set; }
        public IEnumerable<WeaponKillDetail> WeaponStats { get; set; }
        public IEnumerable<MedalStatCounter> Impulses { get; set; }
        public IEnumerable<TeamStat> TeamStats { get; set; }
        public bool IsMatchOver { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public Guid MapVariantId { get; set; }
        public Guid GameVariantId { get; set; }
        public Guid PlaylistId { get; set; }
        public Guid MapId { get; set; }
        public Guid GameBaseVariantId { get; set; }
        public bool IsTeamGame { get; set; }
    }
}