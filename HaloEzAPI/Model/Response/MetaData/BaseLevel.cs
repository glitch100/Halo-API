using System;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class BaseLevel
    {
        public int Threshold { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}