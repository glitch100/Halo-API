using System;
using System.Net;

namespace HaloEzAPI.Model.Response.Error
{
    public class HaloAPIException : Exception
    {
        public string StandardMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
