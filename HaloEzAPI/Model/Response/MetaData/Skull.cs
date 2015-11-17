using System;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Skull: IDetail
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid MissionId { get; set; }
        public uint Id { get; set; }
        public Guid ContentId { get; set; }
    }
}