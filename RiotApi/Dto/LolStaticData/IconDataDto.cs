﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotApi.Dto.LolStaticData
{
    public class IconDataDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public ImageDto Image { get; set; }
    }
}
