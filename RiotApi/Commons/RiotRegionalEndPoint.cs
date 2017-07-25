using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotApi.Commons;

namespace RiotApi.Commons
{
    public class RiotRegionalEndPoint
    {
        /// <summary>
        /// Ottiene il regional EndPoint corrispondete alla region indicata
        /// </summary>
        /// <param name="region">Region del Regional EndPoint che vogliamo ottenere</param>
        /// <returns>Un oggetto contente i dati sul Regional EndPoint</returns>
        public static RegionalEndPoint GetRegionalEndPointByRegion(Enums.Region region)
        { 
            return RegionalEndPoints.FirstOrDefault(x => x.Region == region.ToString());
        }

        /// <summary>
        /// Ottiene il regional EndPoint corrispondete al PlatformID indicato
        /// </summary>
        /// <param name="platformID">PlatformID del Regional EndPoint che vogliamo ottenere</param>
        /// <returns>Un oggetto contente i dati sul Regional EndPoint</returns>
        public static RegionalEndPoint GetRegionalEndPointByPlatformID(Enums.Platform platformID )
        {
            return RegionalEndPoints.FirstOrDefault(x => x.PlatformID == platformID.ToString());
        }
        /// <summary>
        /// Lista contenente tutti i Regional EndPoint
        /// https://developer.riotgames.com/docs/regional-endpoints
        /// </summary>
       // public static readonly IEnumerable<RegionalEndPoint> RegionalEndPoints = new List<RegionalEndPoint>()
        public static readonly List<RegionalEndPoint> RegionalEndPoints = new List<RegionalEndPoint>()
        {
            new RegionalEndPoint {Region = "BR", PlatformID = "BR1",  Host = "br.api.pvp.net"} ,
            new RegionalEndPoint {Region = "EUNE", PlatformID = "EUN1",  Host = "eune.api.pvp.net"} ,
            new RegionalEndPoint {Region = "EUW", PlatformID = "EUW1",  Host = "euw.api.pvp.net"} ,
            new RegionalEndPoint {Region = "JP", PlatformID = "JP1",  Host = "jp.api.pvp.net"} ,
            new RegionalEndPoint {Region = "KR", PlatformID = "KR",  Host = "kr.api.pvp.net"} ,
            new RegionalEndPoint {Region = "LAN", PlatformID = "LA1",  Host = "lan.api.pvp.net"} ,
            new RegionalEndPoint {Region = "LAS", PlatformID = "LA2",  Host = "las.api.pvp.net"} ,
            new RegionalEndPoint {Region = "NA", PlatformID = "NA1",  Host = "na.api.pvp.net"} ,
            new RegionalEndPoint {Region = "OCE", PlatformID = "OC1",  Host = "oce.api.pvp.net"} ,
            new RegionalEndPoint {Region = "TR", PlatformID = "TR1",  Host = "tr.api.pvp.net"} ,
            new RegionalEndPoint {Region = "RU", PlatformID = "RU",  Host = "ru.api.pvp.net"} ,
            new RegionalEndPoint {Region = "PBE", PlatformID = "PBE1",  Host = "pbe.api.pvp.net"} ,
            new RegionalEndPoint {Region = "Global", PlatformID = "",  Host = "global.api.pvp.net"}
        };

        

        /// <summary>
        /// Classe che descrive un EndPoint
        /// </summary>
        public class RegionalEndPoint
        {
            public string Region { get; set; }
            public string PlatformID { get; set; }
            public string Host { get; set; }
        }
    }
}
