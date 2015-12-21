using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Season : IGuidContentIds
    {
        public IEnumerable<Playlist> Playlists { get; set; } 
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}