using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CottontailApi.Commons.CustomJsonConverter
{
    /// <summary>
    /// 
    /// </summary>
    public class MapTypeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            return (Commons.Enums.MapType)(Enum.Parse(typeof(Commons.Enums.MapType), str));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string result = ((int)value).ToString();
            serializer.Serialize(writer, result);
        }
    }
}
