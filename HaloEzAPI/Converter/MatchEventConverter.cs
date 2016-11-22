using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Enum.Utils;
using HaloEzAPI.Model.Response.Stats.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HaloEzAPI.Converter
{
    public class MatchEventConverter : JsonConverter
    {
        public const string EventNameKey = "EventName";
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var events = JArray.Load(reader);
            var eventList = new List<GameEvent>();
            foreach (var e in events)
            {
                var eventType = EnumUtils.ParseEnum<EventType>(e[EventNameKey].Value<string>());
                switch (eventType)
                {
                    case EventType.Death:
                        eventList.Add(e.ToObject<DeathEvent>());
                        break;
                    case EventType.Impulse:
                        eventList.Add(e.ToObject<ImpulseEvent>());
                        break;                    
                    case EventType.RoundStart:
                        eventList.Add(e.ToObject<RoundEvent>());
                        break;                    
                    case EventType.RoundEnd:
                        eventList.Add(e.ToObject<RoundEvent>());
                        break;                    
                    case EventType.Medal:
                        eventList.Add(e.ToObject<MedalEvent>());
                        break;                    
                    case EventType.PlayerSpawn:
                        eventList.Add(e.ToObject<PlayerEvent>());
                        break;                    
                    case EventType.WeaponDrop:
                        eventList.Add(e.ToObject<WeaponDropEvent>());
                        break;                    
                    case EventType.WeaponPickup:
                    case EventType.WeaponPickupPad:
                        eventList.Add(e.ToObject<WeaponEvent>());
                        break;
                    default:
                        eventList.Add(e.ToObject<GameEvent>());
                        break;
                }
            }
            return eventList;
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(GameEvent).IsAssignableFrom(objectType);
        }
    }
}