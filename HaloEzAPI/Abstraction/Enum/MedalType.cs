using System.Runtime.Serialization;

namespace HaloEzAPI.Abstraction.Enum
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
    }
}