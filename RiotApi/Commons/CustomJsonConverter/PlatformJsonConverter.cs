using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Commons.CustomJsonConverter
{
    public class PlatformJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string result = GenericConverter.ConvertPlatformToString((Enums.Platform)value);
            
            serializer.Serialize(writer, result);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();

            return GenericConverter.ConvertStringToPlatform(str);
          /*  switch (str)
            {
                case "NA1":
                    return Enums.Platform.NA1;
                case "BR1":
                    return Enums.Platform.BR1;
                case "LA1":
                    return Enums.Platform.LA1;
                case "LA2":
                    return Enums.Platform.LA2;
                case "OC1":
                    return Enums.Platform.OC1;
                case "EUN1":
                    return Enums.Platform.EUN1;
                case "TR1":
                    return Enums.Platform.TR1;
                case "RU":
                    return Enums.Platform.RU;
                case "EUW1":
                    return Enums.Platform.EUW1;
                case "KR":
                    return Enums.Platform.KR;
                default:
                    return null;
            }*/
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }
    }
}
