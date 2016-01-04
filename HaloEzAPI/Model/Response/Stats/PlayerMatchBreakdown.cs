using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Interfaces;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public abstract class PlayerMatchBreakdown : IPlayerStat
    {
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
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalTimePlayed { get; set; }
        public int TotalGrenadeKills { get; set; }
        public IEnumerable<MedalAward> MedalAwards { get; set; }
        public IEnumerable<Kill> DestroyedEnemyVehicles { get; set; }
        public IEnumerable<Kill> EnemyKills { get; set; }
        public IEnumerable<WeaponKillDetail> WeaponStats { get; set; }
        public IEnumerable<StatCounter<uint>> Impulses { get; set; }
        public int TotalSpartanKills { get; set; }
    }
}