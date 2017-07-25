using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotApi.Commons;

namespace RiotApi.Commons
{
    public class RiotSpectatorEndPoint
    {
        /// <summary>
        /// Ottiene il regional EndPoint corrispondete alla region indicata
        /// </summary>
        /// <param name="region">Region del Regional EndPoint che vogliamo ottenere</param>
        /// <returns>Un oggetto contente i dati sul Regional EndPoint</returns>
        public static SpectatorEndPoint GetSpectatorEndPointByRegion(Enums.Region region)
        { 
            return SpectatorEndPoints.FirstOrDefault(x => x.Region == region.ToString());
        }

        /// <summary>
        /// Ottiene il regional EndPoint corrispondete al PlatformID indicato
        /// </summary>
        /// <param name="platformID">PlatformID del Regional EndPoint che vogliamo ottenere</param>
        /// <returns>Un oggetto contente i dati sul Regional EndPoint</returns>
        public static SpectatorEndPoint GetSpectatorEndPointByPlatformID(Enums.Platform platformID )
        {
            return SpectatorEndPoints.FirstOrDefault(x => x.PlatformID == platformID.ToString());
        }
        /// <summary>
        /// Lista contenente tutti i Spectator EndPoint
        /// https://developer.riotgames.com/docs/spectating-games
        /// </summary>
        public static readonly List<SpectatorEndPoint> SpectatorEndPoints = new List<SpectatorEndPoint>()
        {
            new SpectatorEndPoint {Region = "BR", PlatformID = "BR1",  Host = " spectator.br.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "EUNE", PlatformID = "EUN1",  Host = "spectator.eu.lol.riotgames.com", Port="8088"} ,
            new SpectatorEndPoint {Region = "EUW", PlatformID = "EUW1",  Host = "spectator.euw1.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "JP", PlatformID = "JP1",  Host = "spectator.jp1.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "KR", PlatformID = "KR",  Host = "spectator.kr.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "LAN", PlatformID = "LA1",  Host = "spectator.la1.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "LAS", PlatformID = "LA2",  Host = "spectator.la2.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "NA", PlatformID = "NA1",  Host = "spectator.na.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "OCE", PlatformID = "OC1",  Host = "spectator.oc1.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "TR", PlatformID = "TR1",  Host = "spectator.tr.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "RU", PlatformID = "RU",  Host = "spectator.ru.lol.riotgames.com", Port="80"} ,
            new SpectatorEndPoint {Region = "PBE", PlatformID = "PBE1",  Host = "spectator.pbe1.lol.riotgames.com", Port="8088"}
        };

        /// <summary>
        /// Classe che descrive un EndPoint
        /// </summary>
        public class SpectatorEndPoint
        {
            public string Region { get; set; }
            public string PlatformID { get; set; }
            public string Host { get; set; }
            public string Port { get; set; }
        }
    }
}
