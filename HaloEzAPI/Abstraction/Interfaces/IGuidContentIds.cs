using System;

namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IGuidContentIds
    {
        Guid Id { get; set; }
        Guid ContentId { get; set; }
    }
}