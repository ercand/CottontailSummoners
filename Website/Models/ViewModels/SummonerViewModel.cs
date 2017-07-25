using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using CottontailApi.Commons;
using Website.Entities;
using Website.Helpers;

namespace Website.Models.ViewModels
{
    public class SummonerViewModel
    {
        public SummonerViewModel(List<Entities.MatchData> matchList, List<Entities.Summoner> summoners, Entities.Summoner ownerSummoner)
        {
            this.RecentMatchs = new SummonerRecentMatchViewModel(matchList, summoners, ownerSummoner.RiotSummonerID);
            this.MostPlayedChampions = new List<ViewModels.ChampionStats>();

            // TODO: Verificare se matchList è null e fare un return apposito
            if (matchList.Count == 0 || summoners.Count == 0)
            {
                return;
            }

            var championData = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);

            this.SummonerName = ownerSummoner.Name;
            this.SummonerLevel = ownerSummoner.Level;
            this.RegionName = Website.Helpers.Utility.Platform.PlatformIntToPlatform(ownerSummoner.Platform).ToFriendlyName();
            this.RiotSummonerID = ownerSummoner.RiotSummonerID;
            this.AccountId = ownerSummoner.AccountId;
            this.RegionStr = CottontailApi.Commons.GenericConverter.RegionToString(Helpers.Utility.Region.RegionIntToRegion(matchList[0].Platform)).ToLower();
            this.RegionInt = matchList[0].Platform;
            this.ProfileIconUrl = "http://ddragon.leagueoflegends.com/cdn/" + championData.Version + "/img/profileicon/" + ownerSummoner.ProfileIconId + ".png";

            // Build last update string
            string tempLastUpdate = "Last updated: ";
            TimeSpan tempElapsedTimaLastUpdate = DateTime.UtcNow - ownerSummoner.LastUpdate;
            if (tempElapsedTimaLastUpdate.TotalSeconds <= 60)
            { tempLastUpdate += Math.Floor(tempElapsedTimaLastUpdate.TotalSeconds) + " seconds ago"; }
            else if (tempElapsedTimaLastUpdate.TotalMinutes <= 60)
            { tempLastUpdate += Math.Floor(tempElapsedTimaLastUpdate.TotalMinutes) + " minutes ago"; }
            else if (tempElapsedTimaLastUpdate.TotalHours <= 24)
            { tempLastUpdate += Math.Floor(tempElapsedTimaLastUpdate.TotalHours) + " hours ago"; }
            else
            { tempLastUpdate += Math.Floor(tempElapsedTimaLastUpdate.TotalDays) + " days ago"; }

            this.LastUpdate = tempLastUpdate;
        }

        public void AddMostPlayedChampions(List<PlayerChampionRankedStats> championStats)
        {
            if (championStats == null)
            {
                return;
            }

            var championData = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);

            foreach (var tempChampStats in championStats)
            {
                ChampionStats tempStats = new ViewModels.ChampionStats();

                // Champion info
                tempStats.ChampionImageUrl = tempChampStats.ChampionId == 0 ? "" : "http://ddragon.leagueoflegends.com/cdn/" + championData.Version + "/img/champion/" + championData.Champions.Where(s => s.Value.Id == tempChampStats.ChampionId).Single().Value.Image.Full;
                tempStats.ChampionName = tempChampStats.ChampionId == 0 ? "" : championData.Champions.Where(s => s.Value.Id == tempChampStats.ChampionId).Single().Value.Name;

                // Champion stats
                tempStats.GamePlayed = tempChampStats.GamePlayed;
                tempStats.Wins = tempChampStats.Wins;
                tempStats.Losses = tempChampStats.Losses;

                tempStats.AvgKillsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempChampStats.Kills / (float)tempChampStats.GamePlayed);
                tempStats.AvgDeathsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempChampStats.Deaths / (float)tempChampStats.GamePlayed);
                tempStats.AvgAssistsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempChampStats.Assists / (float)tempChampStats.GamePlayed);

                tempStats.AvgGoldEarnedTextual = ((int)((float)tempChampStats.GoldEarned / (float)tempChampStats.GamePlayed)).ToString();
                tempStats.AvgMinionsKilledTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempChampStats.MinionsKilled / (float)tempChampStats.GamePlayed);

                tempStats.KdaTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)(tempChampStats.Kills + tempChampStats.Assists) / (float)tempChampStats.Deaths);

                // ChampionId = 0 viene ignorato perchè si tratta delle stats totali
                if (tempChampStats.ChampionId != 0)
                    this.MostPlayedChampions.Add(tempStats);
            }

            this.MostPlayedChampions = this.MostPlayedChampions.OrderByDescending(k => k.GamePlayed).ToList();
        }

        public void AddRankedInfo(Entities.PlayerLeague playerLeague)
        {
            if (playerLeague == null)
            {
                this.RankTier = "";
                this.RankDivision = "";
                this.RankedLP = 0;
                this.RankedWin = 0;
                this.RankedLose = 0;

                return;
            }
            this.RankTier = Website.Helpers.Utility.TierToString(playerLeague.Tier);
            this.RankDivision = Website.Helpers.Utility.RankedDivisionToString(playerLeague.Division);
            this.RankedLP = playerLeague.LeaguePoints;
            this.RankedWin = playerLeague.Wins;
            this.RankedLose = playerLeague.Losses;
        }

        public SummonerRecentMatchViewModel RecentMatchs { get; set; }
        public List<ChampionStats> MostPlayedChampions { get; set; }
        public string RegionName { get; set; }
        public string SummonerName { get; set; }
        public int SummonerLevel { get; set; }
        public long RiotSummonerID { get; set; }
        public long AccountId { get; set; }
        public string RegionStr { get; set; }
        public int RegionInt { get; set; }
        public string ProfileIconUrl { get; set; }
        public string LastUpdate { get; set; }

        // Rank stats
        public string RankTier { get; set; }
        public string RankDivision { get; set; }
        public int RankedLP { get; set; }
        public int RankedWin { get; set; }
        public int RankedLose { get; set; }
    }

    #region SummonerRunePageViewModel
    public class SummonerRunePageViewModel
    {
        public SummonerRunePageViewModel(List<Entities.RunePage> runePages)
        {
            var dataRune = (HttpRuntime.Cache[GlobalCustomConstants.RuneData] as CottontailApi.Dto.StaticData.RuneListDto);
            Pages = new List<RunePageDataViewModel>();

            foreach (var page in runePages)
            {
                Dictionary<int, int> tempRuneCount = new Dictionary<int, int>();
                RunePageDataViewModel r = new RunePageDataViewModel();

                r.Name = page.Name;
                r.Current = page.IsCurrent;

                var runes = Website.Helpers.Utility.Rune.RunePageCodeToList(page.RuneCode);
                foreach (var rune in runes)
                {
                    r.RuneList.Add(new RunePageDataViewModel.RuneData()
                    {
                        SlotId = rune.Item1,
                        RuneId = rune.Item2,
                        SanitizedDescription = rune.Item2 == 0 ? "" : "<span style =\"color:#fd4\">" + dataRune.Data[rune.Item2.ToString()].Name + "</span><br />" + dataRune.Data[rune.Item2.ToString()].Description,
                        ImageUrl = rune.Item2 == 0 ? "" : "http://ddragon.leagueoflegends.com/cdn/" + dataRune.Version + "/img/rune/" + dataRune.Data[rune.Item2.ToString()].Image.Full
                    });

                    if (rune.Item2 != 0)
                    {
                        if (tempRuneCount.ContainsKey(rune.Item2))
                        {
                            tempRuneCount[rune.Item2] += 1;
                        }
                        else
                        {
                            tempRuneCount.Add(rune.Item2, 1);
                        }
                    }
                }

                // Imposta i valori delle statistiche generali della pagina di rune
                foreach (var item in tempRuneCount)
                {
                    r.RuneDetails.Add(new RunePageDataViewModel.RuneDataDetails()
                    {
                        ImageUrl = "http://ddragon.leagueoflegends.com/cdn/" + dataRune.Version + "/img/rune/" + dataRune.Data[item.Key.ToString()].Image.Full,
                        Description = dataRune.Data[item.Key.ToString()].Description,

                        Name = dataRune.Data[item.Key.ToString()].Name,
                        Count = item.Value
                    });
                }

                this.Pages.Add(r);
            }
        }

        public List<RunePageDataViewModel> Pages { get; set; }
    }

    public class RunePageDataViewModel
    {
        public RunePageDataViewModel()
        {
            RuneList = new List<RuneData>(30);
            RuneDetails = new List<RuneDataDetails>();
        }
        public string Name { get; set; }
        public bool Current { get; set; }
        public List<RuneData> RuneList { get; set; }
        public List<RuneDataDetails> RuneDetails { get; set; }

        public class RuneData
        {
            public int SlotId { get; set; }
            public int RuneId { get; set; }
            public string ImageUrl { get; set; }
            public string SanitizedDescription { get; set; }
        }

        public class RuneDataDetails
        {
            public string ImageUrl { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public int Count { get; set; }
        }
    }

    #endregion

    #region SummonerMasteryPageViewModel
    public class SummonerMasteryPageViewModel
    {
        public SummonerMasteryPageViewModel(List<Entities.MasteryPage> masteryPages)
        {
            Pages = new List<MasteryPageDataViewModel>();

            foreach (var page in masteryPages)
            {
                MasteryPageDataViewModel masteryPageViewModel = new MasteryPageDataViewModel();

                masteryPageViewModel.Name = page.Name;
                masteryPageViewModel.Current = page.IsCurrent;

                masteryPageViewModel.MasteryList = Website.Helpers.Utility.Mastery.MasteryPageCodeToDictionary(page.MasteryCode);

                // Conta i punti per ogni mastery tree
                foreach (var masterySlot in masteryPageViewModel.MasteryList)
                {
                    var tempMasteryID = masterySlot.Key;

                    if (tempMasteryID >= 6100 && tempMasteryID <= 6199)
                        masteryPageViewModel.FerocityPoint += masterySlot.Value;

                    if (tempMasteryID >= 6200 && tempMasteryID <= 6299)
                        masteryPageViewModel.ResolvePoint += masterySlot.Value;

                    if (tempMasteryID >= 6300 && tempMasteryID <= 6399)
                        masteryPageViewModel.CunningPoint += masterySlot.Value;
                }
                this.Pages.Add(masteryPageViewModel);
            }
        }

        public List<MasteryPageDataViewModel> Pages { get; set; }
    }

    public class MasteryPageDataViewModel
    {
        public MasteryPageDataViewModel()
        { }

        public string Name { get; set; }
        public bool Current { get; set; }

        public int FerocityPoint { get; set; }
        public int CunningPoint { get; set; }
        public int ResolvePoint { get; set; }

        public string SanitizedDescription { get; set; }
        public Dictionary<int, int> MasteryList { get; set; }
    }

    #endregion

    #region SummonerRecentMatchViewModel

    public class SummonerRecentMatchViewModel
    {
        public SummonerRecentMatchViewModel(List<Entities.MatchData> matchList, List<Entities.Summoner> summoners, long riotSummonerID)
        {
            this.Matchs = new List<SummonerRecentMatchDataViewModel>();
            this.MostPlayedChampions = new List<ViewModels.ChampionStats>();

            // TODO: Verificare se matchList è null e fare un return apposito
            if (matchList.Count == 0 || summoners.Count == 0)
            {
                return;
            }

            int tempTotalKill = 0, tempTotalAssist = 0, tempTotalDeath = 0;
            RecentPlayed = matchList.Count;
            RecentWin = matchList.SelectMany(s => s.DataParticipant).Where(p => p.RiotSummonerID == riotSummonerID && p.Winner == true).Count();
            RecentLosses = RecentPlayed - RecentWin;
            PercentageWinRate = (int)((float)RecentWin / (float)RecentPlayed * 100.0);
            RegionStr = Utility.Platform.ToString(Utility.Platform.PlatformIntToPlatform(matchList[0].Platform)).ToLower();
            this.RiotSummonerID = riotSummonerID;
            RegionInt = matchList[0].Platform;



            var championData = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);
            var itemData = (HttpRuntime.Cache[GlobalCustomConstants.ItemData] as CottontailApi.Dto.StaticData.ItemListDto);
            var summonerSpellData = (HttpRuntime.Cache[GlobalCustomConstants.SummonerSpellData] as CottontailApi.Dto.StaticData.SummonerSpellListDto);

            string emptyItem = "/images/blank2.png";
            matchList = matchList.OrderByDescending(m => m.MatchCreation).ToList();
            foreach (var match in matchList)
            {
                SummonerRecentMatchDataViewModel tempData = new SummonerRecentMatchDataViewModel();

                tempData.QueueType = (CottontailApi.Commons.GenericConverter.StringToGameQueueType(match.QueueId.ToString())).ToFriendlyName();
                tempData.Win = match.DataParticipant.Where(s => s.RiotSummonerID == riotSummonerID).Single().Winner;
                tempData.DateCreation = Utility.FromMillisecondsEpochToDateTime(match.MatchCreation).ToString("dd/MM/yyyy");
                tempData.MatchDuration = (int)(new TimeSpan(0, 0, (int)match.MatchDuration).TotalMinutes) + "m " + new TimeSpan(0, 0, (int)match.MatchDuration).Seconds + "s";

                // Stats player
                foreach (var player in match.DataParticipant)
                {
                    var tempParticipantStats = match.DataParticipantStats.Where(s => s.ParticipantId == player.ParticipantId).SingleOrDefault();
                    SummonerRecentMatchDataViewModel.PlayersStats tempPlayerStats = new SummonerRecentMatchDataViewModel.PlayersStats();
                    { };
                    tempPlayerStats.ChampionImageUrl = player.ChampionId == 0 ? "" : "http://ddragon.leagueoflegends.com/cdn/" + championData.Version + "/img/champion/" + championData.Champions.Where(s => s.Value.Id == player.ChampionId).Single().Value.Image.Full;
                    tempPlayerStats.Spell1IdImageUrl = player.Spell1Id == 0 || match.MatchMode == "SIEGE" ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + summonerSpellData.Version + "/img/spell/" + summonerSpellData.SummonerSpells.Where(s => s.Value.Id == player.Spell1Id).SingleOrDefault().Value.Image.Full;
                    tempPlayerStats.Spell2IdImageUrl = player.Spell2Id == 0 || match.MatchMode == "SIEGE" ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + summonerSpellData.Version + "/img/spell/" + summonerSpellData.SummonerSpells.Where(s => s.Value.Id == player.Spell2Id).SingleOrDefault().Value.Image.Full;

                    tempPlayerStats.Item0ImageUrl = player.Item0 == 0 || !itemData.Data.ContainsKey(player.Item0) ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + itemData.Version + "/img/item/" + itemData.Data[player.Item0].Image.Full;
                    tempPlayerStats.Item1ImageUrl = player.Item1 == 0 || !itemData.Data.ContainsKey(player.Item1) ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + itemData.Version + "/img/item/" + itemData.Data[player.Item1].Image.Full;
                    tempPlayerStats.Item2ImageUrl = player.Item2 == 0 || !itemData.Data.ContainsKey(player.Item2) ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + itemData.Version + "/img/item/" + itemData.Data[player.Item2].Image.Full;
                    tempPlayerStats.Item3ImageUrl = player.Item3 == 0 || !itemData.Data.ContainsKey(player.Item3) ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + itemData.Version + "/img/item/" + itemData.Data[player.Item3].Image.Full;
                    tempPlayerStats.Item4ImageUrl = player.Item4 == 0 || !itemData.Data.ContainsKey(player.Item4) ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + itemData.Version + "/img/item/" + itemData.Data[player.Item4].Image.Full;
                    tempPlayerStats.Item5ImageUrl = player.Item5 == 0 || !itemData.Data.ContainsKey(player.Item5) ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + itemData.Version + "/img/item/" + itemData.Data[player.Item5].Image.Full;
                    tempPlayerStats.TrinketImageUrl = player.Item6 == 0 || !itemData.Data.ContainsKey(player.Item6) ? emptyItem : "http://ddragon.leagueoflegends.com/cdn/" + itemData.Version + "/img/item/" + itemData.Data[player.Item6].Image.Full;

                    tempPlayerStats.ChampionLevel = match.DataParticipantStats.Where(s => s.ParticipantId == player.ParticipantId).SingleOrDefault() != null ? match.DataParticipantStats.Where(s => s.ParticipantId == player.ParticipantId).SingleOrDefault().ChampionLevel : 0;
                    tempPlayerStats.Assists = player.Assists;
                    tempPlayerStats.Kills = player.Kills;
                    tempPlayerStats.Deaths = player.Deaths;
                    tempPlayerStats.KDA = player.Deaths == 0 ? "perfect KDA" : String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.00}", (float)(player.Kills + player.Assists) / (float)player.Deaths);
                    tempPlayerStats.GoldEarned = player.GoldEarned;
                    tempPlayerStats.GoldPerMinut = (int)((float)player.GoldEarned / ((float)match.MatchDuration / 60.0));
                    tempPlayerStats.GoldEarnedTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", player.GoldEarned / 1000.0f);
                    tempPlayerStats.MinionPerMinutTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", ((float)(player.NeutralMinionsKilled + player.MinionsKilled)) / ((float)match.MatchDuration / 60.0));
                    tempPlayerStats.Wards = tempParticipantStats != null ? tempParticipantStats.WardsPlaced : 0;

                    tempPlayerStats.MinionsKilled = player.MinionsKilled;
                    tempPlayerStats.NeutralMinionsKilled = player.NeutralMinionsKilled;
                    tempPlayerStats.NeutralMinionsKilledEnemyJungle = player.NeutralMinionsKilledEnemyJungle;
                    tempPlayerStats.NeutralMinionsKilledTeamJungle = player.NeutralMinionsKilledTeamJungle;
                    tempPlayerStats.TeamId = player.TeamId;
                    tempPlayerStats.SummonerName = summoners.Where(s => s.RiotSummonerID == player.RiotSummonerID).SingleOrDefault().Name;


                    if (player.RiotSummonerID == riotSummonerID)
                    {
                        tempData.OwnerPlayerStats = tempPlayerStats;

                        // Somma totale kill assist death
                        tempTotalAssist += player.Assists;
                        tempTotalKill += player.Kills;
                        tempTotalDeath += player.Deaths;
                    }
                    //  else
                    {
                        tempData.PlayerStats.Add(tempPlayerStats);
                    }


                }
                Matchs.Add(tempData);
            }

            // Calcolo finale kill assist death
            AvgKillsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempTotalKill / (float)RecentPlayed);
            AvgDeathsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempTotalDeath / (float)RecentPlayed);
            AvgAssistsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempTotalAssist / (float)RecentPlayed);
            KdaTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)(tempTotalKill + tempTotalAssist) / (float)tempTotalDeath);
        }
        public void AddMostPlayedChampions(List<PlayerChampionRankedStats> championStats)
        {
            if (championStats == null)
            {
                return;
            }

            var championData = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);

            foreach (var tempChampStats in championStats)
            {
                ChampionStats tempStats = new ViewModels.ChampionStats();

                // Champion info
                tempStats.ChampionImageUrl = tempChampStats.ChampionId == 0 ? "" : "http://ddragon.leagueoflegends.com/cdn/" + championData.Version + "/img/champion/" + championData.Champions.Where(s => s.Value.Id == tempChampStats.ChampionId).Single().Value.Image.Full;
                tempStats.ChampionName = tempChampStats.ChampionId == 0 ? "" : championData.Champions.Where(s => s.Value.Id == tempChampStats.ChampionId).Single().Value.Name;

                // Champion stats
                tempStats.GamePlayed = tempChampStats.GamePlayed;
                tempStats.Wins = tempChampStats.Wins;
                tempStats.Losses = tempChampStats.Losses;

                tempStats.AvgKillsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempChampStats.Kills / (float)tempChampStats.GamePlayed);
                tempStats.AvgDeathsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempChampStats.Deaths / (float)tempChampStats.GamePlayed);
                tempStats.AvgAssistsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempChampStats.Assists / (float)tempChampStats.GamePlayed);

                tempStats.AvgGoldEarnedTextual = ((int)((float)tempChampStats.GoldEarned / (float)tempChampStats.GamePlayed)).ToString();
                tempStats.AvgMinionsKilledTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)tempChampStats.MinionsKilled / (float)tempChampStats.GamePlayed);

                tempStats.KdaTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)(tempChampStats.Kills + tempChampStats.Assists) / (float)tempChampStats.Deaths);

                // ChampionId = 0 viene ignorato perchè si tratta delle stats totali
                if (tempChampStats.ChampionId != 0)
                    this.MostPlayedChampions.Add(tempStats);
            }

            this.MostPlayedChampions = this.MostPlayedChampions.OrderByDescending(k => k.GamePlayed).ToList();
        }

        public List<SummonerRecentMatchDataViewModel> Matchs { get; set; }
        public List<ChampionStats> MostPlayedChampions { get; set; }
        public long RiotSummonerID { get; set; }
        public string RegionStr { get; set; }
        public int RegionInt { get; set; }
        public int RecentPlayed { get; set; }
        public int RecentWin { get; set; }
        public int RecentLosses { get; set; }
        public int PercentageWinRate { get; set; }
        public string AvgKillsTextual { get; set; }
        public string AvgDeathsTextual { get; set; }
        public string AvgAssistsTextual { get; set; }
        public string KdaTextual { get; set; }

    }

    public class SummonerRecentMatchDataViewModel
    {
        public string QueueType { get; set; }
        public bool Win { get; set; }
        public string DateCreation { get; set; }


        /// <summary>
        /// Match duration in seconds
        /// </summary>
        public string MatchDuration { get; set; }

        public PlayersStats OwnerPlayerStats { get; set; }
        public List<PlayersStats> PlayerStats { get; set; }

        public SummonerRecentMatchDataViewModel()
        {
            PlayerStats = new List<PlayersStats>();
        }

        public class PlayersStats
        {
            public string SummonerName { get; set; }
            public int ChampionLevel { get; set; }
            public string ChampionImageUrl { get; set; }

            /// <summary>
            /// First summoner spell ID
            /// </summary>
            public string Spell1IdImageUrl { get; set; }

            /// <summary>
            /// Second summoner spell ID
            /// </summary>
            public string Spell2IdImageUrl { get; set; }

            /// <summary>
            /// Team ID
            /// </summary>
            public int TeamId { get; set; }

            public string Item0ImageUrl { get; set; }
            public string Item1ImageUrl { get; set; }
            public string Item2ImageUrl { get; set; }
            public string Item3ImageUrl { get; set; }
            public string Item4ImageUrl { get; set; }
            public string Item5ImageUrl { get; set; }
            public string TrinketImageUrl { get; set; }

            public int GoldEarned { get; set; }
            public string GoldEarnedTextual { get; set; }
            public int GoldPerMinut { get; set; }
            public string MinionPerMinutTextual { get; set; }

            public int Kills { get; set; }
            public int Deaths { get; set; }
            public int Assists { get; set; }

            public string KDA { get; set; }
            public int Wards { get; set; }
            /// <summary>
            /// Total minion in lane
            /// </summary>
            public int MinionsKilled { get; set; }

            /// <summary>
            /// Total minion killed in jungle(team and enemy jungle)
            /// </summary>
            public int NeutralMinionsKilled { get; set; }
            public int NeutralMinionsKilledEnemyJungle { get; set; }
            public int NeutralMinionsKilledTeamJungle { get; set; }
        }
    }


    #endregion

    #region SummonerChampionStatsViewModel

    public class SummonerChampionStatsViewModel
    {
        public SummonerChampionStatsViewModel(List<Website.Entities.PlayerChampionRankedStats> playerStats, Website.Entities.PlayerLeague league = null)
        {
            var championData = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);
            var tempStats = new List<ChampionStats>();

            foreach (var stats in playerStats)
            {
                ChampionStats championTempStats = new ChampionStats();

                // Champion info
                championTempStats.ChampionImageUrl = stats.ChampionId == 0 ? "" : "http://ddragon.leagueoflegends.com/cdn/" + championData.Version + "/img/champion/" + championData.Champions.Where(s => s.Value.Id == stats.ChampionId).Single().Value.Image.Full;
                championTempStats.ChampionName = stats.ChampionId == 0 ? "" : championData.Champions.Where(s => s.Value.Id == stats.ChampionId).Single().Value.Name;

                // Champion stats
                championTempStats.GamePlayed = stats.GamePlayed;
                championTempStats.Wins = stats.Wins;
                championTempStats.Losses = stats.Losses;

                championTempStats.AvgKillsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)stats.Kills / (float)stats.GamePlayed);
                championTempStats.AvgDeathsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)stats.Deaths / (float)stats.GamePlayed);
                championTempStats.AvgAssistsTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)stats.Assists / (float)stats.GamePlayed);
                championTempStats.KdaTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)(stats.Kills + stats.Assists) / (float)stats.Deaths);

                championTempStats.AvgGoldEarnedTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:#,##0.##}", ((int)((float)stats.GoldEarned / (float)stats.GamePlayed)));
                championTempStats.AvgMinionsKilledTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:0.0}", (float)stats.MinionsKilled / (float)stats.GamePlayed);

                championTempStats.MaxKills = stats.MaxChampionsKilled;
                championTempStats.MaxDeaths = stats.MaxNumDeaths;
                championTempStats.AvgDamageDealtTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:#,##0.##}", (int)((float)stats.DamageDealt / (float)stats.GamePlayed));
                championTempStats.AvgDamageTakenTextual = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:#,##0.##}", (int)((float)stats.DamageTaken / (float)stats.GamePlayed));
                championTempStats.DoubleKills = stats.DoubleKills;
                championTempStats.TripleKills = stats.TripleKills;
                championTempStats.QuadraKills = stats.QuadraKills;
                championTempStats.PentaKills = stats.PentaKills;
                championTempStats.Season = stats.Season;

                // ChampionId = 0 viene ignorato perchè si tratta delle stats totali
                // if (stats.ChampionId != 0)
                tempStats.Add(championTempStats);
            }
            //
            if (league!=null)
            {
                GamesCount = league.Wins + league.Losses;
            }
            else
            {
                GamesCount = 0;
            }
            Stats = tempStats.GroupBy(s => s.Season).OrderByDescending(d => d.Key).ToDictionary(x => x.Key, u => u.ToList());
        }

        public int GamesCount { get; set; }
        public Dictionary<int, List<ChampionStats>> Stats { get; set; }
    }

    #endregion

    #region SummonerLeagueViewModel

    public class SummonerLeagueViewModel
    {
        public SummonerLeagueViewModel(CottontailApi.Dto.League.LeagueListDto league, List<Entities.Summoner> summoner, long ownerSummonerRiotId)
        { //
            this.Name = league.Name;
            this.OwnerDivision = Utility.RankedDivisionToInt(league.Entries.Where(entry => long.Parse(entry.PlayerOrTeamId) == ownerSummonerRiotId).Single().Rank);
            this.Tier = GenericConverter.TierTypeToString(league.Tier);
            this.Region = Utility.Platform.ToString(Utility.Platform.PlatformIntToPlatform(summoner[0].Platform)).ToLower();

            this.Leagues = new List<SummonerLeagueDivisionDataViewModel>(5);

            for (int i = 0; i < 5; i++)
            {
                var entryByDivision = league.Entries.Where(entry => Utility.RankedDivisionToInt(entry.Rank) == i + 1).OrderBy(e => e.MiniSeries == null).ThenByDescending(e => e.LeaguePoints).ToList();

                if (entryByDivision.Count() > 0)
                {
                    SummonerLeagueDivisionDataViewModel t = new SummonerLeagueDivisionDataViewModel(entryByDivision, summoner);
                    Leagues.Add(t);
                }
                else
                {
                    Leagues.Add(new SummonerLeagueDivisionDataViewModel());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<SummonerLeagueDivisionDataViewModel> Leagues { get; set; }
        public string Name { get; set; }
        public long OwnerDivision { get; set; }
        public string Region { get; set; }
        public string Tier { get; set; }
    }

    public class SummonerLeagueDivisionDataViewModel
    {
        public SummonerLeagueDivisionDataViewModel()
        { }
        public SummonerLeagueDivisionDataViewModel(List<CottontailApi.Dto.League.LeagueItemDto> summonerEntries, List<Entities.Summoner> summoner)
        {
            var championData = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);
            this.SummonerLeagueInfo = new List<SummonerLeagueDataViewModel>();

            foreach (var tempSummoner in summonerEntries)
            {
                SummonerLeagueDataViewModel tempLeague = new SummonerLeagueDataViewModel();

                tempLeague.Division = tempSummoner.Rank;
                tempLeague.IsFreshBlood = tempSummoner.FreshBlood;
                tempLeague.IsHotStreak = tempSummoner.HotStreak;
                tempLeague.IsInactive = tempSummoner.Inactive;
                tempLeague.IsVeteran = tempSummoner.Veteran;
                tempLeague.LeaguePoints = tempSummoner.LeaguePoints;
                tempLeague.Losses = tempSummoner.Losses;
                tempLeague.Wins = tempSummoner.Wins;
                tempLeague.WinRate = "" + (int)(((float)tempSummoner.Wins / (float)(tempSummoner.Wins + tempSummoner.Losses)) * 100.0);
                tempLeague.PlayerOrTeamId = tempSummoner.PlayerOrTeamId;
                tempLeague.PlayerOrTeamName = tempSummoner.PlayerOrTeamName;
                tempLeague.ProfileIconUrl = "http://ddragon.leagueoflegends.com/cdn/" + championData.Version + "/img/profileicon/" + summoner.Where(sum => sum.RiotSummonerID == Int32.Parse(tempSummoner.PlayerOrTeamId)).SingleOrDefault().ProfileIconId + ".png";

                if (tempSummoner.MiniSeries != null)
                {
                    tempLeague.IsInPromotion = true;
                    tempLeague.SeriesLosses = tempSummoner.MiniSeries.Losses;
                    tempLeague.SeriesProgress = tempSummoner.MiniSeries.Progress;
                    tempLeague.SeriesTarget = tempSummoner.MiniSeries.Target;
                    tempLeague.SeriesWins = tempSummoner.MiniSeries.Wins;
                }


                SummonerLeagueInfo.Add(tempLeague);
            }
        }
        public List<SummonerLeagueDataViewModel> SummonerLeagueInfo { get; private set; }
    }

    public class SummonerLeagueDataViewModel
    {
        public SummonerLeagueDataViewModel()
        {
            this.IsInPromotion = false;
        }

        public string Division { get; set; }
        public bool IsFreshBlood { get; set; }
        public bool IsHotStreak { get; set; }
        public bool IsInactive { get; set; }
        public bool IsVeteran { get; set; }
        public int LeaguePoints { get; set; }
        public int Losses { get; set; }
        public int Wins { get; set; }
        public string WinRate { get; set; }
        public string Playstyle { get; set; }
        public string PlayerOrTeamId { get; set; }
        public string PlayerOrTeamName { get; set; }
        public string ProfileIconUrl { get; set; }

        // Series info
        public bool IsInPromotion { get; set; }
        public int SeriesLosses { get; set; }
        public string SeriesProgress { get; set; }
        public int SeriesTarget { get; set; }
        public int SeriesWins { get; set; }

    }

    #endregion

    #region LiveGameViewModel

    public class SummonerLiveGameViewModel
    {
        public SummonerLiveGameViewModel(CottontailApi.Dto.Spectator.CurrentGameInfo currentGame, List<Summoner> summoners, List<PlayerLeague> playersLeague, List<PlayerChampionRankedStats> playerStats)
        {
            var dataSummonerSpell = (HttpRuntime.Cache[GlobalCustomConstants.SummonerSpellData] as CottontailApi.Dto.StaticData.SummonerSpellListDto);
            var dataChampion = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);

            this.LiveGame = new LiveGameDataModel();


            LiveGameDataModel newGM = new LiveGameDataModel();

            newGM.Region = Utility.Platform.ToString(currentGame.PlatformId).ToLower();
            newGM.Map = ((CottontailApi.Commons.Enums.MapType)currentGame.MapId).ToFriendlyName();
            newGM.GameMode = currentGame.GameQueueConfigId.ToFriendlyName();
            newGM.GameStartTime = Utility.SecondElapsedFromEpoch(currentGame.GameStartTime);

            // Ban
            foreach (var ban in currentGame.BannedChampions)
            {
                LiveGameDataModel.Ban newBan = new LiveGameDataModel.Ban() { ChampionId = (int)ban.ChampionId, Turn = (int)ban.PickTurn, Team = (int)ban.TeamId, ChampionUrl = "http://ddragon.leagueoflegends.com/cdn/" + dataChampion.Version + "/img/champion/" + dataChampion.Champions.Where(s => s.Value.Id == (int)ban.ChampionId).Single().Value.Image.Full };
                newGM.Bans.Add(newBan);
            }

            // Player
            foreach (var participant in currentGame.Participants)
            {
                var temSumm = summoners.Where(s => s.Name == participant.SummonerName).SingleOrDefault();
                var tempLeague = playersLeague.Where(s => s.ID == temSumm.ID).SingleOrDefault();
                var tempStats = playerStats.Where(x => x.RiotSummonerID == temSumm.RiotSummonerID && x.ChampionId == participant.ChampionId).SingleOrDefault();

                LiveGameDataModel.PlayerData newParticipant = new LiveGameDataModel.PlayerData();

                newParticipant.Name = temSumm.Name;
                newParticipant.ChampionId = (int)participant.ChampionId;
                newParticipant.Spell1 = (int)participant.Spell1Id;
                newParticipant.Spell2 = (int)participant.Spell2Id;

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

                // Mastery
                foreach (var masteryPoint in participant.Masteries)
                {
                    int masteryId = (int)masteryPoint.MasteryId;
                    int masteryRank = masteryPoint.Rank;

                    // Conta i punti per ogni mastery tree
                    if (masteryId >= 6100 && masteryId <= 6199)
                        newParticipant.Mastery.FerocityPoint += masteryRank;

                    if (masteryId >= 6200 && masteryId <= 6299)
                        newParticipant.Mastery.ResolvePoint += masteryRank;

                    if (masteryId >= 6300 && masteryId <= 6399)
                        newParticipant.Mastery.CunningPoint += masteryRank;

                    newParticipant.Mastery.MasteryList.Add(masteryId, masteryRank);
                }

                // Rune
                if (participant.Runes != null)
                {
                    var tempRuneData = (HttpRuntime.Cache[GlobalCustomConstants.RuneData] as CottontailApi.Dto.StaticData.RuneListDto);
                    foreach (var rune in participant.Runes)
                    {
                        string tempDescription = tempRuneData.Data[rune.RuneId.ToString()].Description;

                        //
                        string finalDescription = "", desc = "", finalValue = "";
                        bool isPercentage = true;
                        string valueString = "";
                        float value = 0;

                        if (tempDescription.Contains("level"))
                        {
                            int substringIndex = tempDescription.IndexOf('(');
                            valueString = tempDescription.Substring(substringIndex + 1, tempDescription.Length - substringIndex - 1).Split(' ')[0];
                            isPercentage = valueString[valueString.Length - 1] == '%';

                            string type = tempDescription.Substring(0, substringIndex).TrimEnd();
                            desc = type.Substring(type.IndexOf(' '), type.IndexOf(" per level") - type.IndexOf(' ')).Trim() + " at level 18";

                            if (isPercentage)
                            {
                                float.TryParse(valueString.Substring(0, valueString.Length - 1), NumberStyles.Any, CultureInfo.InvariantCulture, out value);
                                finalValue = (value > 0.0 ? "+" : "") + ((float)Math.Round(value * (double)rune.Count, 1)).ToString() + "% ";
                                finalDescription = char.ToUpper(desc[0]) + desc.Substring(1); ;
                            }
                            else
                            {
                                float.TryParse(valueString.Substring(0, valueString.Length), NumberStyles.Any, CultureInfo.InvariantCulture, out value);
                                finalValue = (value > 0.0 ? "+" : "") + ((float)Math.Round(value * (double)rune.Count, 1)).ToString();
                                finalDescription = char.ToUpper(desc[0]) + desc.Substring(1);
                            }
                        }
                        else if (tempDescription.ToLower().Contains("lethality") && tempDescription.ToLower().Contains("magic penetration"))
                        {
                            string[] split = tempDescription.Split('/');
                            string lethality = split[0].Trim().Split(' ')[0].Trim();
                            string magicpenetration = split[1].Trim().Split(' ')[0].Trim();

                            // parse
                            float valueLethality = 0;
                            float valueMagicPenetration = 0;
                            float.TryParse(lethality, NumberStyles.Any, CultureInfo.InvariantCulture, out valueLethality);
                            float.TryParse(magicpenetration, NumberStyles.Any, CultureInfo.InvariantCulture, out valueMagicPenetration);

                            valueLethality = (float)Math.Round(valueLethality * (double)rune.Count, 1);
                            valueMagicPenetration = (float)Math.Round(valueMagicPenetration * (double)rune.Count, 1);

                            finalValue = "+" + valueLethality + " / " + "+" + valueMagicPenetration;
                            finalDescription = "Lethality / Magic Penetration";
                        }
                        else
                        {
                            valueString = tempDescription.Split(' ')[0];
                            isPercentage = valueString[valueString.Length - 1] == '%';

                            desc = tempDescription.Substring(tempDescription.IndexOf(' ')).Trim();

                            if (isPercentage)
                            {
                                float.TryParse(valueString.Substring(0, valueString.Length - 1), NumberStyles.Any, CultureInfo.InvariantCulture, out value);
                                finalValue = (value > 0.0 ? "+" : "") + ((float)Math.Round(value * (double)rune.Count, 1)).ToString() + "% ";
                                finalDescription = char.ToUpper(desc[0]) + desc.Substring(1); ;
                            }
                            else
                            {
                                float.TryParse(valueString.Substring(0, valueString.Length), NumberStyles.Any, CultureInfo.InvariantCulture, out value);
                                finalValue = (value > 0.0 ? "+" : "") + ((float)Math.Round(value * (double)rune.Count, 1)).ToString();
                                finalDescription = char.ToUpper(desc[0]) + desc.Substring(1); ;
                            }
                        }
                        newParticipant.Rune.RuneDetails.Add(new LiveGameDataModel.RunePageData.RuneDataDetails()
                        {
                            //ImageUrl = "http://ddragon.leagueoflegends.com/cdn/" + tempRuneData.Version + "/img/rune/" + tempRuneData.Data[(int)rune.RuneId].Image.Full,
                            Description = finalDescription,
                            Value = finalValue,

                            //Name = tempRuneData.Data[(int)rune.RuneId].Name,
                            Count = rune.Count
                        });
                    }
                }
                //
                newParticipant.ChampionUrl = "http://ddragon.leagueoflegends.com/cdn/" + dataChampion.Version + "/img/champion/" + dataChampion.Champions.Where(s => s.Value.Id == (int)participant.ChampionId).Single().Value.Image.Full;
                newParticipant.Spell1Url = "http://ddragon.leagueoflegends.com/cdn/" + dataSummonerSpell.Version + "/img/spell/" + dataSummonerSpell.SummonerSpells.Where(x => x.Value.Id == (int)participant.Spell1Id).Single().Value.Image.Full;
                newParticipant.Spell2Url = "http://ddragon.leagueoflegends.com/cdn/" + dataSummonerSpell.Version + "/img/spell/" + dataSummonerSpell.SummonerSpells.Where(x => x.Value.Id == (int)participant.Spell2Id).Single().Value.Image.Full;

                if (participant.TeamId == 100)
                    newGM.TeamBluePlayersData.Add(newParticipant);
                else
                    newGM.TeamRedPlayersData.Add(newParticipant);
            }
            this.LiveGame = newGM;

        }

        public LiveGameDataModel LiveGame { get; set; }
    }

    public class LiveGameDataModel
    {
        public LiveGameDataModel()
        {
            Bans = new List<Ban>(6);
            TeamBluePlayersData = new List<PlayerData>(5);
            TeamRedPlayersData = new List<PlayerData>(5);
        }

        public string Region { get; set; }
        public string Map { get; set; }
        public string GameMode { get; set; }
        public int GameStartTime { get; set; }
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
                TotalRankedWin = 0;
                TotaleRankedLose = 0;
                RankedWinRate = 0;


                //Champion stats
                TotalChampionRankedWin = 0;
                TotalChampionRankedLose = 0;
                ChampionAverangeKill = "0.0";
                ChampionAverangeDeath = "0.0";
                ChampionAverangeAssist = "0.0";
                ChampionWinRate = 0;
                ChampionKDA = "0.0";

                Mastery = new MasteryPageData();
                Rune = new RunePageData();
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

            public MasteryPageData Mastery { get; set; }
            public RunePageData Rune { get; set; }
        }

        public class RunePageData
        {
            public RunePageData()
            {
                RuneDetails = new List<RuneDataDetails>();
            }

            public List<RuneDataDetails> RuneDetails { get; set; }

            public class RuneDataDetails
            {
                //  public string ImageUrl { get; set; }
                //  public string Name { get; set; }
                public string Description { get; set; }

                public string Value { get; set; }

                public int Count { get; set; }
            }
        }
        public class MasteryPageData
        {
            public MasteryPageData()
            {
                MasteryList = new Dictionary<int, int>();
            }

            public int FerocityPoint { get; set; }
            public int CunningPoint { get; set; }
            public int ResolvePoint { get; set; }
            public Dictionary<int, int> MasteryList { get; set; }
        }
    }

    #endregion
    public class ChampionStats
    {
        // Champion info
        public string ChampionImageUrl { get; set; }
        public string ChampionName { get; set; }

        // Statistiche sulle partite giocate
        public int Season { get; set; }
        public int GamePlayed { get; set; }
        public int Losses { get; set; }
        public int Wins { get; set; }
        public string AvgKillsTextual { get; set; }
        public string AvgDeathsTextual { get; set; }
        public string AvgAssistsTextual { get; set; }
        public string KdaTextual { get; set; }
        public string AvgMinionsKilledTextual { get; set; }
        public string AvgGoldEarnedTextual { get; set; }
        public int MaxKills { get; set; }
        public int MaxDeaths { get; set; }
        public string AvgDamageDealtTextual { get; set; }
        public string AvgDamageTakenTextual { get; set; }
        public int DoubleKills { get; set; }
        public int TripleKills { get; set; }
        public int QuadraKills { get; set; }
        public int PentaKills { get; set; }

    }
}