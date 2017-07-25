using Ninject;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.App_Start
{
    public class NinjectJobFactory : SimpleJobFactory
    {
        private readonly IKernel resolutionRoot;

        public NinjectJobFactory(IKernel resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob)this.resolutionRoot.Get(bundle.JobDetail.JobType);
        }

        public override void ReturnJob(IJob job)
        {
            string dud = "";
        }
    }
}