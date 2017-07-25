using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using CottontailApi;
using CottontailApi.Commons;
using Website.Helpers;

namespace Website.ScheduledTask
{
    public class UpdateStaticDataJob : IJob
    {
        IStaticRiotApiClient _riotClient;
        private UpdateStaticDataJob()
        { }

        public UpdateStaticDataJob(IStaticRiotApiClient riotClient)
        {
            this._riotClient = riotClient;
        }
        public void Execute(IJobExecutionContext context)
        {
            //             "n": {
            //       "profileicon": "7.1.1",
            //       "map": "7.1.1",
            //       "language": "7.1.1",
            //    },
            Console.Beep();
            Console.WriteLine("Scheduler 2 secondi");
            // Ultima versione disponibile
            var real = this._riotClient.Realms(CottontailApi.Commons.Enums.Platform.NA1);

            // Champions
            var dataChampion = (HttpRuntime.Cache[GlobalCustomConstants.ChampionData] as CottontailApi.Dto.StaticData.ChampionListDto);
            if (real.N["champion"].ToLower() != dataChampion.Version.ToLower())
            {
                // Get new data
                var newDataChampion = this._riotClient.GetChampions(CottontailApi.Commons.Enums.Platform.NA1, StaticDataEnums.ChampionData.All);
                var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/" + GlobalCustomConstants.ChampionData + ".json");

                // Serialize data to file
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, newDataChampion);
                }

                // Update data
                HttpRuntime.Cache.Remove(GlobalCustomConstants.ChampionData);
                HttpRuntime.Cache[GlobalCustomConstants.ChampionData] = newDataChampion;
            }


            // Summoner Spells
            var dataSummonerSpell = (HttpRuntime.Cache[GlobalCustomConstants.SummonerSpellData] as CottontailApi.Dto.StaticData.SummonerSpellListDto);
            if (real.N["summoner"].ToLower() != dataSummonerSpell.Version.ToLower())
            {
                // Get new data
                var newSummonerSpellData = this._riotClient.GetSummonerSpells(CottontailApi.Commons.Enums.Platform.NA1, StaticDataEnums.SummonerSpellData.All);
                var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/" + GlobalCustomConstants.SummonerSpellData + ".json");

                // Serialize data to file
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, newSummonerSpellData);
                }

                // Update data
                HttpRuntime.Cache.Remove(GlobalCustomConstants.SummonerSpellData);
                HttpRuntime.Cache[GlobalCustomConstants.SummonerSpellData] = newSummonerSpellData;
            }

            // Rune
            var dataRuneData = (HttpRuntime.Cache[GlobalCustomConstants.RuneData] as CottontailApi.Dto.StaticData.RuneListDto);
            if (real.N["rune"].ToLower() != dataRuneData.Version.ToLower())
            {
                // Get new data
                var newRuneData = this._riotClient.GetRunes(CottontailApi.Commons.Enums.Platform.NA1, StaticDataEnums.RuneData.All);
                var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/" + GlobalCustomConstants.RuneData + ".json");

                // Serialize data to file
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, newRuneData);
                }

                // Update data
                HttpRuntime.Cache.Remove(GlobalCustomConstants.RuneData);
                HttpRuntime.Cache[GlobalCustomConstants.RuneData] = newRuneData;
            }

            // Item
            var dataItemData = (HttpRuntime.Cache[GlobalCustomConstants.ItemData] as CottontailApi.Dto.StaticData.ItemListDto);
            if (real.N["item"].ToLower() != dataItemData.Version.ToLower())
            {
                // Get new data
                var newItemData = this._riotClient.GetItems(CottontailApi.Commons.Enums.Platform.NA1, StaticDataEnums.ItemData.All);
                var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/" + GlobalCustomConstants.ItemData + ".json");

                // Serialize data to file
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, newItemData);
                }

                // Update data
                HttpRuntime.Cache.Remove(GlobalCustomConstants.ItemData);
                HttpRuntime.Cache[GlobalCustomConstants.ItemData] = newItemData;
            }

            // mastery
            var dataMasteriesData = (HttpRuntime.Cache[GlobalCustomConstants.MasteriesData] as CottontailApi.Dto.StaticData.MasteryListDto);
            if (real.N["mastery"].ToLower() != dataMasteriesData.Version.ToLower())
            {
                // Get new data
                var newMasteriesData = this._riotClient.GetMasteries(CottontailApi.Commons.Enums.Platform.NA1, StaticDataEnums.MasteryData.All);
                var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/" + GlobalCustomConstants.MasteriesData + ".json");

                // Serialize data to file
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, newMasteriesData);
                }

                // Update data
                HttpRuntime.Cache.Remove(GlobalCustomConstants.MasteriesData);
                HttpRuntime.Cache[GlobalCustomConstants.MasteriesData] = newMasteriesData;
            }
        }
    }
}