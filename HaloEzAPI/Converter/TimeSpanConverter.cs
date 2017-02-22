using System;
using System.Xml;
using Newtonsoft.Json;

namespace HaloEzAPI.Converter
{
    /// <summary>
    /// Taken from: http://stackoverflow.com/questions/12633588/parsing-iso-duration-with-json-net
    /// </summary>
    public class TimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var ts = (TimeSpan)value;
            var tsString = XmlConvert.ToString(ts);
            serializer.Serialize(writer, tsString);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<String>(reader);
            if (value == string.Empty)
            {
                return TimeSpan.MinValue;
            }
            return XmlConvert.ToTimeSpan(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }
    }
}
