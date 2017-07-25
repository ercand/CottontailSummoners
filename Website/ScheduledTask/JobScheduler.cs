using Ninject;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.ScheduledTask
{
    public class JobScheduler
    {
        public static void Start()
        {
            var kernel = DependencyResolver.Current.GetService<IKernel>();
            IScheduler scheduler = kernel.Get<IScheduler>();// StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<UpdateStaticDataJob>().WithIdentity("UpdateStaticDataJob").Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithSimpleSchedule
                  (s =>
                     s.WithIntervalInSeconds(3600).RepeatForever())
                .Build();

            //             ITrigger trigger = TriggerBuilder.Create()
            //                 .WithDailyTimeIntervalSchedule
            //                   (s =>
            //                      s.WithIntervalInHours(24)
            //                     .OnEveryDay()
            //                     .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
            //                   )
            //                 .Build();

            scheduler.ScheduleJob(job, trigger);

            //
            foreach (CottontailApi.Commons.Enums.Platform platform in Enum.GetValues(typeof(CottontailApi.Commons.Enums.Platform)))
            {
                if (platform != CottontailApi.Commons.Enums.Platform.PBE1)
                {
                    IJobDetail jobProcessMatch = JobBuilder.Create<RankedMatchProcessingJob>().WithIdentity("RankedMatchProcessingJob"+platform).Build();
                    jobProcessMatch.JobDataMap[RankedMatchProcessingJob.Platform] = platform;

                    ITrigger triggerProcessMatch = TriggerBuilder.Create()
                        .WithSimpleSchedule
                          (s =>
                             s.WithIntervalInSeconds(1).RepeatForever())
                        .Build();

                    scheduler.ScheduleJob(jobProcessMatch, triggerProcessMatch);
                }
            }
            /*IJobDetail jobProcessMatch = JobBuilder.Create<RankedMatchProcessingJob>().WithIdentity("RankedMatchProcessingJob").Build();
            jobProcessMatch.JobDataMap[RankedMatchProcessingJob.Platform] = CottontailApi.Commons.Enums.Platform.EUW1;

            ITrigger triggerProcessMatch = TriggerBuilder.Create()
                .WithSimpleSchedule
                  (s =>
                     s.WithIntervalInSeconds(1).RepeatForever())
                .Build();

            scheduler.ScheduleJob(jobProcessMatch, triggerProcessMatch);*/
        }
    }
}