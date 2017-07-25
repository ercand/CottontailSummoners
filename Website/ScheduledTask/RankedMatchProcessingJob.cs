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
using Website.Entities;
using Website.Services.Interfaces;
using System.Threading.Tasks;

namespace Website.ScheduledTask
{
    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]
    public class RankedMatchProcessingJob : IJob
    {
        public static readonly string Platform = "Platform";
        IRiotApiClient _riotClient;
        IRankedMatchToProcessService _matchToProcessService;
        IMatchService _matchService;
        CottontailApi.Commons.Enums.Platform platform;

        private RankedMatchProcessingJob()
        {
        }

        public RankedMatchProcessingJob(IRiotApiClient riotClient, IRankedMatchToProcessService matchToProcessService, IMatchService matchService)
        {
            this._riotClient = riotClient;
            this._matchToProcessService = matchToProcessService;
            this._matchService = matchService;
        }
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            platform = (CottontailApi.Commons.Enums.Platform)dataMap.Get(Platform);

            var toProcess = this._matchToProcessService.GetRecent(10, platform).ToList();

            foreach (var match in toProcess)
            {
                float usage = this._riotClient.GetApiUsage(CottontailApi.Commons.Enums.Platform.EUW1);
#warning togliere questo Trace
                System.Diagnostics.Trace.WriteLine("Api Usage: " + usage);

                if (usage > 80)
                    return;
                var p = Utility.Platform.PlatformIntToPlatform(match.Platform);
                var r = this._matchService.Find(match.RiotMatchID, p);

                if (r!=null)
                {
                    this._matchToProcessService.Delete(match);

                }
            }

        }

        private void Process()
        {
            List<Task> t = new List<Task>();
            foreach (CottontailApi.Commons.Enums.Platform platform in Enum.GetValues(typeof(CottontailApi.Commons.Enums.Platform)))
            {
                var result = Task.Run(() => SingleTask(this._matchToProcessService, this._riotClient, this._matchService, platform));
                t.Add(result);
            }

            Task.WhenAll(t).Wait();
        }

        private void SingleTask(IRankedMatchToProcessService matchToProcessService, IRiotApiClient riotClient, IMatchService matchService, CottontailApi.Commons.Enums.Platform platform)
        {
            var toProcess = matchToProcessService.GetRecent(10, platform).ToList();

            foreach (var match in toProcess)
            {
                float usage = riotClient.GetApiUsage(CottontailApi.Commons.Enums.Platform.EUW1);

                System.Diagnostics.Trace.WriteLine("Api Usage: " + usage);

                if (usage > 80)
                    return;
                var p = Utility.Platform.PlatformIntToPlatform(match.Platform);
                var r = matchService.Find(match.RiotMatchID, p);

                if (r != null)
                {
                    matchToProcessService.Delete(match);

                }
            }
        }
    }
}