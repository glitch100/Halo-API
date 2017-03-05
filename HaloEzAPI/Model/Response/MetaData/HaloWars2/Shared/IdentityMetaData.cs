using System;
using HaloEzAPI.Abstraction.Enum.HaloWars2;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared
{
    public class IdentityMetaData
    {
        public int Id { get; set; }
        public ContentTypeEnum Type { get; set; }
        public Guid Identity { get; set; }
        public string AutoRoute { get; set; }
    }
}