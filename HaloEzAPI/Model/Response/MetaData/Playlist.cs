using System;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Playlist : IDetail, IGuidContentIds
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRanked { get; set; }
        public string ImageUrl { get; set; }
        public GameMode GameMode { get; set; }
        public bool IsActive { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}