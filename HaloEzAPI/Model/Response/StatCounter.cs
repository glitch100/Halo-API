using System;

namespace HaloEzAPI.Model.Response
{
    public class StatCounter<T>
    {
        public T Id { get; set; }
        public int Count { get; set; }
    }
}