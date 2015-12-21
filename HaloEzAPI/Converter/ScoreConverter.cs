using System;
using Newtonsoft.Json;

namespace HaloEzAPI.Converter
{
    public class ScoreConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            uint unsignedValue;
            unchecked
            {
                // Have to cast to an int first because value is an Int32
                unsignedValue = (uint)(int)value;
            }

            serializer.Serialize(writer, unsignedValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            uint unsignedValue = serializer.Deserialize<uint>(reader);

            int signedValue;
            unchecked
            {
                signedValue = (int)unsignedValue;
            }

            return signedValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }
    }
}
