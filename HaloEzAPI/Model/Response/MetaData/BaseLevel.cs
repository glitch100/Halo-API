using System;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class BaseLevel : IGuidContentIds
    {
        public int Threshold { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}