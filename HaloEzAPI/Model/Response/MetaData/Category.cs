using System;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Category
    {
        public string Name { get; set; }
        public string IconImageUrl { get; set; }
        public int Order { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}