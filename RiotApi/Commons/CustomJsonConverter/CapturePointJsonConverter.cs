﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Commons.CustomJsonConverter
{
    class CapturePointJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var subType = (Enums.CapturePoint)value;

            string result = GenericConverter.CapturePointToString(subType);
            
            serializer.Serialize(writer, result);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();

            return GenericConverter.StringToCapturePoint(str);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }
    }
}
