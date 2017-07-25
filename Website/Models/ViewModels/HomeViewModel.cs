using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Website.Entities;
using Website.Helpers;

namespace Website.Models.ViewModels
{
    public class HomeFeatureGameViewModel
    {
        public HomeFeatureGameViewModel(CottontailApi.Dto.Spectator.FeaturedGames featureGames, List<Summoner> summoners, List<PlayerLeague> playersLeague, List<PlayerChampionRankedStats> playerStats)
        {
            var dataSummonerSpell = (HttpRuntime.Cache[GlobalCustomConstants.SummonerSpellData] as CottontailApi.Dto.StaticData.SummonerSpellListDto);
            var dataChampion = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);

            this.FeatureGame = new List<FeatureGameModel>(5);
            foreach (var game in featureGames.GameList)
            {

                FeatureGameModel newGM = new FeatureGameModel();

                newGM.RegionName = game.PlatformId.ToFriendlyName();
                newGM.Region = Utility.Platform.ToString(game.PlatformId).ToLower();
                newGM.Map = game.MapId.ToFriendlyName();
                newGM.GameMode = game.GameQueueConfigId.ToFriendlyName();
                newGM.GameStartTime = Utility.SecondElapsedFromEpoch(game.GameStartTime);
                newGM.EncryptionKey = HttpUtility.UrlEncode(game.Observers.EncryptionKey);
                newGM.MatchId = game.GameId;

                // Ban
                foreach (var ban in game.BannedChampions)
                {
                    FeatureGameModel.Ban newBan = new FeatureGameModel.Ban();
                    newBan.ChampionId = (int)ban.ChampionId;
                    newBan.Turn = (int)ban.PickTurn;
                    newBan.Team = (int)ban.TeamId;

                    var tempImg = dataChampion.Champions.Where(s => s.Value.Id == (int)ban.ChampionId).SingleOrDefault();
                    newBan.ChampionUrl = tempImg.Equals(default(KeyValuePair<string, CottontailApi.Dto.StaticData.ChampionDto>)) == false ? "http://ddragon.leagueoflegends.com/cdn/" + dataChampion.Version + "/img/champion/" + tempImg.Value.Image.Full : ""; 


                    newGM.Bans.Add(newBan);
                }

                // Player
                foreach (var partecipant in game.Participants)
                {
                    var temSumm = summoners.Where(s => s.Name == partecipant.SummonerName).SingleOrDefault();
                    var tempLeague = playersLeague.Where(s => s.ID == temSumm.ID).SingleOrDefault();
                    var tempStats = playerStats.Where(x => x.RiotSummonerID == temSumm.RiotSummonerID && x.ChampionId == partecipant.ChampionId).SingleOrDefault();
                    
                    FeatureGameModel.PlayerData newParticipant = new FeatureGameModel.PlayerData();
                    
                    newParticipant.Name = temSumm.Name;
                    newParticipant.ChampionId = (int)partecipant.ChampionId;
                    newParticipant.Spell1 = (int)partecipant.Spell1Id;
                    newParticipant.Spell2 = (int)partecipant.Spell2Id;

                    if (tempLeague != null)
                    {
                        newParticipant.Division = tempLeague.Division;
                        newParticipant.Tier = tempLeague.Tier;
                        newParticipant.LeaguePoint = tempLeague.LeaguePoints;
                        newParticipant.TotalRankedWin = (int)tempLeague.Wins;
                        newParticipant.TotaleRankedLose = tempLeague.Losses;
                        newParticipant.RankedWinRate = (int)((float)tempLeague.Wins / (float)(tempLeague.Losses + tempLeague.Wins) * 100.0);
                    }

                    //Champion stats
                    if (tempStats != null)
                    {
                        float totalGame = tempStats.Wins + tempStats.Losses;
                        string avgK = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", tempStats.Kills / totalGame);
                        string avgD = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", tempStats.Deaths / totalGame);
                        string avgA = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", tempStats.Assists / totalGame);
                        string avgKDA = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)(tempStats.Kills + tempStats.Assists) / ((float)(tempStats.Deaths != 0 ? tempStats.Deaths : 1)));
                        newParticipant.TotalChampionRankedWin = tempStats.Wins;
                        newParticipant.TotalChampionRankedLose = tempStats.Losses;
                        newParticipant.ChampionAverangeKill = avgK;
                        newParticipant.ChampionAverangeDeath = avgD;
                        newParticipant.ChampionAverangeAssist = avgA;
                        newParticipant.ChampionWinRate = (int)((float)tempStats.Wins / (float)(tempStats.Losses + tempStats.Wins) * 100.0);
                        newParticipant.ChampionKDA = avgKDA;
                    }

                    //
                    newParticipant.ChampionUrl = "http://ddragon.leagueoflegends.com/cdn/" + dataChampion.Version + "/img/champion/" + dataChampion.Champions.Where(s => s.Value.Id == (int)partecipant.ChampionId).Single().Value.Image.Full;
                    newParticipant.Spell1Url = "http://ddragon.leagueoflegends.com/cdn/" + dataSummonerSpell.Version + "/img/spell/" + dataSummonerSpell.SummonerSpells.Where(x => x.Value.Id == (int)partecipant.Spell1Id).Single().Value.Image.Full;
                    newParticipant.Spell2Url = "http://ddragon.leagueoflegends.com/cdn/" + dataSummonerSpell.Version + "/img/spell/" + dataSummonerSpell.SummonerSpells.Where(x => x.Value.Id == (int)partecipant.Spell2Id).Single().Value.Image.Full;

                    if (partecipant.TeamId == 100)
                        newGM.TeamBluePlayersData.Add(newParticipant);
                    else
                        newGM.TeamRedPlayersData.Add(newParticipant);
                }
                this.FeatureGame.Add(newGM);
            }
        }

        public List<FeatureGameModel> FeatureGame { get; set; }
    }

    public class FeatureGameModel
    {
        public FeatureGameModel()
        {
            Bans = new List<Ban>(6);
            TeamBluePlayersData = new List<PlayerData>(5);
            TeamRedPlayersData = new List<PlayerData>(5);
        }

        public string RegionName { get; set; }
        public string Region { get; set; }
        public string Map { get; set; }
        public string GameMode { get; set; }
        public int GameStartTime { get; set; }
        public string EncryptionKey { get; set; }
        public long MatchId { get; set; }
        public List<Ban> Bans { get; set; }
        public List<PlayerData> TeamBluePlayersData { get; set; }
        public List<PlayerData> TeamRedPlayersData { get; set; }

        public class Ban
        {
            public int ChampionId { get; set; }
            public int Turn { get; set; }
            public int Team { get; set; }
            public string ChampionUrl { get; set; }
        }
        public class PlayerData
        {
            public PlayerData()
            {
                Division = 0;
                Tier = 0;
                LeaguePoint = 0;
                TotalRankedWin = -1;
                TotaleRankedLose = -1;
                RankedWinRate = -1;


                //Champion stats
                TotalChampionRankedWin = -1;
                TotalChampionRankedLose = -1;
                ChampionAverangeKill = "0.0";
                ChampionAverangeDeath = "0.0";
                ChampionAverangeAssist = "0.0";
                ChampionWinRate = -1;
                ChampionKDA = "0.0";
            }
            public string Name { get; set; }
            public int Tier { get; set; }
            public int Division { get; set; }
            public int LeaguePoint { get; set; }
            public int ChampionId { get; set; }
            public int Spell1 { get; set; }
            public int Spell2 { get; set; }
            public int TotalRankedWin { get; set; }
            public int TotaleRankedLose { get; set; }
            public int TotalChampionRankedWin { get; set; }
            public int TotalChampionRankedLose { get; set; }
            public string ChampionAverangeKill { get; set; }
            public string ChampionAverangeDeath { get; set; }
            public string ChampionAverangeAssist { get; set; }

            // 
            public int RankedWinRate { get; set; }
            public int ChampionWinRate { get; set; }
            public string ChampionKDA { get; set; }

            //
            public string ChampionUrl { get; set; }
            public string Spell1Url { get; set; }
            public string Spell2Url { get; set; }
        }
    }
}