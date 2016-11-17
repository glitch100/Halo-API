using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloEzAPI.Model.Response.UGC
{
    public class TimeUtc
    {
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime ISO8601Date { get; set; }
    }
}