using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Dto.StaticData
{
    public class MasteryDto
    {
        /// <summary>
        /// List of string descripting the mastery.
        /// </summary>
        [JsonProperty("description")]
        public List<string> Description { get; set; }

        /// <summary>
        /// Mastery's id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Mastery's image.
        /// </summary>
        [JsonProperty("image")]
        public ImageDto Image { get; set; }

        /// <summary>
        /// Mastery's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Id of the prerequisite mastery.
        /// </summary>
        [JsonProperty("prereq")]
        public string Prerequisite { get; set; }

        /// <summary>
        /// Mastery's rank.
        /// </summary>
        [JsonProperty("ranks")]
        public int Rank { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the mastery.
        /// </summary>
        [JsonProperty("sanitizedDescription")]
        public List<string> SanitizedDescription { get; set; }

        /// <summary>
        /// (Legal values: Cunning, Ferocity, Resolve)
        /// </summary>
        [JsonProperty("masteryTree")]
        public string MasteryTree{ get; set; }
    }
    
}
