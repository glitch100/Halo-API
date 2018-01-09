using System.Runtime.Serialization;

namespace HaloEzAPI.Abstraction.Enum.Halo5
{
    public enum MedalType
    {
        Unknown,
        [EnumMember(Value = "Multi-kill")]
        MultiKill,
        Spree,
        Style,
        Warzone,
        Vehicles,
        Breakout,
        Objective,
        StrongHolds,
        KillingSpree,
        CaptureTheFlag,
        WeaponProficiency,
        Ball,
        Infection,
        Oddball,
    }
}