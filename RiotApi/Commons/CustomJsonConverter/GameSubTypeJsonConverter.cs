using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Commons.CustomJsonConverter
{
    public class GameSubTypeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var subType = (Enums.GameSubType)value;
            string result;
            switch (subType)
            {
                case Enums.GameSubType.ARAM_UNRANKED_5x5:
                    result = "ARAM_UNRANKED_5x5";
                    break;
                case Enums.GameSubType.BOT:
                    result = "BOT";
                    break;
                case Enums.GameSubType.BOT_3x3:
                    result = "BOT_3x3";
                    break;
                case Enums.GameSubType.FIRSTBLOOD_1x1:
                    result = "FIRSTBLOOD_1x1";
                    break;
                case Enums.GameSubType.FIRSTBLOOD_2x2:
                    result = "FIRSTBLOOD_2x2";
                    break;
                case Enums.GameSubType.HEXAKILL:
                    result = "HEXAKILL";
                    break;
                case Enums.GameSubType.NONE:
                    result = "NONE";
                    break;
                case Enums.GameSubType.NORMAL:
                    result = "NORMAL";
                    break;
                case Enums.GameSubType.NORMAL_3x3:
                    result = "NORMAL_3x3";
                    break;
                case Enums.GameSubType.ODIN_UNRANKED:
                    result = "ODIN_UNRANKED";
                    break;
                case Enums.GameSubType.ONEFORALL_5x5:
                    result = "ONEFORALL_5x5";
                    break;
                case Enums.GameSubType.RANKED_PREMADE_3x3:
                    result = "RANKED_PREMADE_3x3";
                    break;
                case Enums.GameSubType.RANKED_PREMADE_5x5:
                    result = "RANKED_PREMADE_5x5";
                    break;
                case Enums.GameSubType.RANKED_SOLO_5x5:
                    result = "RANKED_SOLO_5x5";
                    break;
                case Enums.GameSubType.RANKED_TEAM_3x3:
                    result = "RANKED_TEAM_3x3";
                    break;
                case Enums.GameSubType.RANKED_TEAM_5x5:
                    result = "RANKED_TEAM_5x5";
                    break;
                case Enums.GameSubType.CAP_5x5:
                    result = "CAP_5x5";
                    break;
                case Enums.GameSubType.URF:
                    result = "URF";
                    break;
                case Enums.GameSubType.URF_BOT:
                    result = "URF_BOT";
                    break;
                case Enums.GameSubType.NIGHTMARE_BOT:
                    result = "NIGHTMARE_BOT";
                    break;
                case Enums.GameSubType.ASCENSION:
                    result = "ASCENSION";
                    break;
                case Enums.GameSubType.KING_PORO:
                    result = "KING_PORO";
                    break;
                case Enums.GameSubType.SIEGE:
                    result = "SIEGE";
                    break;
                case Enums.GameSubType.COUNTER_PICK:
                    result = "COUNTER_PICK";
                    break;
                case Enums.GameSubType.BILGEWATER:
                    result = "BILGEWATER";
                    break;
                case Enums.GameSubType.RANKED_FLEX_SR:
                    result = "RANKED_FLEX_SR";
                    break;
                case Enums.GameSubType.RANKED_FLEX_TT:
                    result = "RANKED_FLEX_TT";
                    break;
                case Enums.GameSubType.DARKSTAR:
                    result = "DARKSTAR";
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            serializer.Serialize(writer, result);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            switch (str)
            {
                case "NONE":
                    return Enums.GameSubType.NONE;
                case "NORMAL":
                    return Enums.GameSubType.NORMAL;
                case "BOT":
                    return Enums.GameSubType.BOT;
                case "RANKED_SOLO_5x5":
                    return Enums.GameSubType.RANKED_SOLO_5x5;
                case "RANKED_PREMADE_3x3":
                    return Enums.GameSubType.RANKED_PREMADE_3x3;
                case "RANKED_PREMADE_5x5":
                    return Enums.GameSubType.RANKED_PREMADE_5x5;
                case "ODIN_UNRANKED":
                    return Enums.GameSubType.ODIN_UNRANKED;
                case "RANKED_TEAM_3x3":
                    return Enums.GameSubType.RANKED_TEAM_3x3;
                case "RANKED_TEAM_5x5":
                    return Enums.GameSubType.RANKED_TEAM_5x5;
                case "NORMAL_3x3":
                    return Enums.GameSubType.NORMAL_3x3;
                case "BOT_3x3":
                    return Enums.GameSubType.BOT_3x3;
                case "CAP_5x5":
                    return Enums.GameSubType.CAP_5x5;
                case "ARAM_UNRANKED_5x5":
                    return Enums.GameSubType.ARAM_UNRANKED_5x5;
                case "ONEFORALL_5x5":
                    return Enums.GameSubType.ONEFORALL_5x5;
                case "FIRSTBLOOD_1x1":
                    return Enums.GameSubType.FIRSTBLOOD_1x1;
                case "FIRSTBLOOD_2x2":
                    return Enums.GameSubType.FIRSTBLOOD_2x2;
                case "SR_6x6":
                    return Enums.GameSubType.SR_6x6;
                case "URF":
                    return Enums.GameSubType.URF;
                case "URF_BOT":
                    return Enums.GameSubType.URF_BOT;
                case "NIGHTMARE_BOT":
                    return Enums.GameSubType.NIGHTMARE_BOT;
                case "ASCENSION":
                    return Enums.GameSubType.ASCENSION;
                case "HEXAKILL":
                    return Enums.GameSubType.HEXAKILL;
                case "KING_PORO":
                    return Enums.GameSubType.KING_PORO;
                case "SIEGE":
                    return Enums.GameSubType.SIEGE;
                case "COUNTER_PICK":
                    return Enums.GameSubType.COUNTER_PICK;
                case "BILGEWATER":
                    return Enums.GameSubType.BILGEWATER;
                case "RANKED_FLEX_SR":
                    return Enums.GameSubType.RANKED_FLEX_SR;
                case "RANKED_FLEX_TT":
                    return Enums.GameSubType.RANKED_FLEX_TT;
                case "DARKSTAR":
                    return Enums.GameSubType.DARKSTAR;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }
    }
}
