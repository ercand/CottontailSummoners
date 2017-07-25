﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Dto.StaticData
{
    public class ImageDto
    {
        /// <summary>
        /// Full name for this image.
        /// </summary>
        [JsonProperty("full")]
        public string Full { get; set; }

        /// <summary>
        /// Image's group (spell, champion, item, etc).
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// Image's height.
        /// </summary>
        [JsonProperty("h")]
        public int Height { get; set; }

        /// <summary>
        /// Image's sprite.
        /// </summary>
        [JsonProperty("sprite")]
        public string Sprite { get; set; }

        /// <summary>
        /// Image's width.
        /// </summary>
        [JsonProperty("w")]
        public int Width { get; set; }

        /// <summary>
        /// X starting point for this image.
        /// </summary>
        [JsonProperty("x")]
        public int X { get; set; }

        /// <summary>
        /// Y starting point for this image.
        /// </summary>
        [JsonProperty("y")]
        public int Y { get; set; }
    }
}
