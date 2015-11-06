using System;
using System.Net;

namespace HaloEzAPI.Model.Response.Error
{
    public class HaloAPIException : Exception
    {
        public HaloAPIException(string message) : base(message)
        {
            
        }
    }
}
