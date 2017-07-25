using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStaticData
{
    public class MasteryTreeDto
    {
        /// <summary>
        /// List of list of objects (masteryId, prereq) in the defense tree.
        /// </summary>
        [JsonProperty("Cunning")]
        public List<MasteryTreeListDto> Cunning { get; set; }

        /// <summary>
        /// List of list of objects (masteryId, prereq) in the offense tree.
        /// </summary>
        [JsonProperty("Ferocity")]
        public List<MasteryTreeListDto> Ferocity { get; set; }

        /// <summary>
        /// List of list of objects (masteryId, prereq) in the utility tree.
        /// </summary>
        [JsonProperty("Resolve")]
        public List<MasteryTreeListDto> Resolve { get; set; }
    }
}