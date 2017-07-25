using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStaticData
{
    public class MasteryTreeItemDto
    {
        /// <summary>
        /// Id of the mastery.
        /// </summary>
        [JsonProperty("masteryId")]
        public int MasteryId { get; set; }

        /// <summary>
        /// Prerequisite.
        /// </summary>
        [JsonProperty("prereq")]
        public string Prerequisite { get; set; }
    }
}
