using System;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Medal : IDetail
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public MedalType Classification { get; set; }
        public int Difficulty { get; set; }
        public SpriteLocation SpriteLocation { get; set; }
        public uint Id { get; set; }
        public Guid ContentId { get; set; }
    }
}