﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.League
{
    /// <summary>
    /// This object contains mini series information.
    /// </summary>
    public class MiniSeriesDto
    {
        /// <summary>
        /// Number of current losses in the mini series.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// String showing the current, sequential mini series progress where 'W' represents a win, 'L' represents a loss, and 'N' represents a game that hasn't been played yet.
        /// </summary>
        [JsonProperty("progress")]
        public string Progress { get; set; }

        /// <summary>
        /// Number of wins required for promotion.
        /// </summary>
        [JsonProperty("target")]
        public int Target { get; set; }

        /// <summary>
        /// Number of current wins in the mini series.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; } 
    }
}
