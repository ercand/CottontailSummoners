using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Commons.CustomJsonConverter
{
    public class GameTypeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var subType = (Enums.GameType)value;
            string result;
            result = GenericConverter.GameTypeToString(subType);
            /*
            switch (subType)
            {
                case Enums.GameType.CUSTOM_GAME:
                    result = "CUSTOM_GAME";
                    break;
                case Enums.GameType.TUTORIAL_GAME:
                    result = "TUTORIAL_GAME";
                    break;
                case Enums.GameType.MATCHED_GAME:
                    result = "MATCHED_GAME";
                    break;
                default:
                    result = string.Empty;
                    break;
            }*/
            serializer.Serialize(writer, result);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();

            return GenericConverter.StringToGameType(str);
            /*switch (str)
            {
                case "CUSTOM_GAME":
                    return Enums.GameType.CUSTOM_GAME;
                case "TUTORIAL_GAME":
                    return Enums.GameType.TUTORIAL_GAME;
                case "MATCHED_GAME":
                    return Enums.GameType.MATCHED_GAME;
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
