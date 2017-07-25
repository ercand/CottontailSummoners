﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStaticData
{
    public class MasteryTreeListDto
    {
        /// <summary>
        /// List of mastery tree items.
        /// </summary>
        [JsonProperty("masteryTreeItems")]
        public List<MasteryTreeItemDto> MasteryTreeItems { get; set; }
    }
}
