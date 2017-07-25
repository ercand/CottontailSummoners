using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Helpers;
/*

<appSettings>
<add key="CompanyTelNo" value="012345 678 910" />
</appSettings>

Then in your code, you can reference it with:

ConfigurationSettings.AppSettings["CompanyTelNo"];

However, since that's actually deprecated, it's better to use:

ConfigurationManager.AppSettings["CompanyTelNo"]


*/
namespace Website.Models.ViewModels
{
    public class LeaderboardsViewModel
    {
        public LeaderboardsViewModel(CottontailApi.Dto.League.LeagueListDto league, List<Entities.Summoner> summoner)
        {
            var championData = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);
            this.Leagues = new List<LeaderboardsDataViewModel>();
            this.Region = Utility.Platform.ToString(Utility.Platform.PlatformIntToPlatform(summoner[0].Platform)).ToLower();

            foreach (var item in league.Entries)
            {
                LeaderboardsDataViewModel tempEntity = new LeaderboardsDataViewModel();

                tempEntity.SummonerName = item.PlayerOrTeamName;
                tempEntity.LeaguePoint = item.LeaguePoints;
                tempEntity.Tier = CottontailApi.Commons.GenericConverter.TierTypeToString(league.Tier);
                tempEntity.Wins = item.Wins;
                tempEntity.Losses = item.Losses;
                tempEntity.WinRatio= "" + (int)(((float)item.Wins / (float)(item.Wins + item.Losses)) * 100.0);
                tempEntity.ProfileIconUrl = "http://ddragon.leagueoflegends.com/cdn/" + championData.Version + "/img/profileicon/" + summoner.Where(sum => sum.RiotSummonerID == Int32.Parse(item.PlayerOrTeamId)).SingleOrDefault().ProfileIconId + ".png";

                this.Leagues.Add(tempEntity);
            }

            this.Leagues = this.Leagues.OrderByDescending(s => s.LeaguePoint).ToList();
        }
        public List<LeaderboardsDataViewModel> Leagues { get; set; }

        public string Region { get; set; }
    }

    public class LeaderboardsDataViewModel
    {
        public LeaderboardsDataViewModel()
        { }

        public string SummonerName { get; set; }
        public int LeaguePoint { get; set; }
        public string Tier { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string WinRatio { get; set; }
        public string ProfileIconUrl { get; set; }
        public string Region { get; set; }
    }
}
