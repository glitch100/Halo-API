using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    public class MatchCompletedDate
    {
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime ISO8601Date { get; set; }
    }
}