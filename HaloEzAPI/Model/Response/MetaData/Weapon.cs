using System;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Weapon : IDetail
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public WeaponType Type { get; set; }
        public string LargeIconImageUrl { get; set; }
        public string SmallIconImageUrl { get; set; }
        public bool IsUsableByPlayer { get; set; }
        public uint Id { get; set; }
        public Guid ContentId { get; set; }
    }
}