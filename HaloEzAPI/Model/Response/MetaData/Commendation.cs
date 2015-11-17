using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Commendation : IGuidContentIds, IDetail
    {
        public CommendationType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconImageUrl { get; set; }
        public IEnumerable<Level> Levels { get; set; }
        public IEnumerable<BaseLevel> RequiredLevels { get; set; }
        public Reward Reward { get; set; }
        public Category Category { get; set; }
        public bool Enabled { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}