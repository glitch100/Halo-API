using System;
using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData.Halo5
{
    public class CampaignMission : IGuidContentIds, IDetail
    {
        public int MissionNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public MissionType Type { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}
