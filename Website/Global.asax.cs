using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Website.Helpers;
using Website.ScheduledTask;

namespace Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //
            var championData = Newtonsoft.Json.JsonConvert.DeserializeObject<CottontailApi.Dto.StaticData.ChampionListDto>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/" + GlobalCustomConstants.ChampionData + ".json")));
            HttpRuntime.Cache.Add(GlobalCustomConstants.ChampionData, championData, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);

            var summonerSpellData = Newtonsoft.Json.JsonConvert.DeserializeObject <CottontailApi.Dto.StaticData.SummonerSpellListDto>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/" + GlobalCustomConstants.SummonerSpellData + ".json")));
            HttpRuntime.Cache.Add(GlobalCustomConstants.SummonerSpellData, summonerSpellData, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);

            var runesData = Newtonsoft.Json.JsonConvert.DeserializeObject<CottontailApi.Dto.StaticData.RuneListDto>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/" + GlobalCustomConstants.RuneData + ".json")));
            HttpRuntime.Cache.Add(GlobalCustomConstants.RuneData, runesData, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);

            var itemData = Newtonsoft.Json.JsonConvert.DeserializeObject<CottontailApi.Dto.StaticData.ItemListDto>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/" + GlobalCustomConstants.ItemData + ".json")));
            HttpRuntime.Cache.Add(GlobalCustomConstants.ItemData, itemData, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);

            var masteriesData = Newtonsoft.Json.JsonConvert.DeserializeObject<CottontailApi.Dto.StaticData.MasteryListDto>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/" + GlobalCustomConstants.MasteriesData + ".json")));
            HttpRuntime.Cache.Add(GlobalCustomConstants.MasteriesData, masteriesData, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable, null);

            // Start Schedule
            JobScheduler.Start();
        }
    }
}
