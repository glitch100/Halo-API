using System;

namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IEquipmentDamageDealt
    {
        double TotalGrenadeDamage { get; set; }
        int TotalPowerWeaponKills { get; set; }
        double TotalPowerWeaponDamage { get; set; }
        int TotalPowerWeaponGrabs { get; set; }
        DateTime TotalPowerWeaponPossesionTime { get; set; }
        int TotalGrenadeKills { get; set; }
    }
}