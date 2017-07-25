[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Website.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Website.App_Start.NinjectWebCommon), "Stop")]

namespace Website.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Website.DataAccessLayer.Repositories;
    using Website.DataAccessLayer.Repositories.Interfaces;
    using Website.DataAccessLayer.UnitOfWork;
    using Website.Services;
    using Website.Services.Interfaces;
    using Quartz;
    using Quartz.Impl;
    using System.Configuration;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Quartz.net
            kernel.Bind<IScheduler>().ToMethod(x =>
            {
                var sched = new StdSchedulerFactory().GetScheduler();
                sched.JobFactory = new NinjectJobFactory(kernel);
                return sched;
            });


            string api_key = ConfigurationManager.AppSettings["ApiKey"];
            
            kernel.Bind<CottontailApi.IRiotApiClient>().To<CottontailApi.RiotApiClient>().InSingletonScope().WithConstructorArgument(api_key);
            kernel.Bind<CottontailApi.IStaticRiotApiClient>().To<CottontailApi.StaticRiotApiClient>().InSingletonScope().WithConstructorArgument(api_key); 
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();//.InSingletonScope();
            kernel.Bind<ISummonerRepository>().To<SummonerRepository>();
            kernel.Bind<ISummonerService>().To<SummonerService>();

            kernel.Bind<IPlayerLeagueRepository>().To<PlayerLeagueRepository>();
            kernel.Bind<IPlayerLeagueService>().To<PlayerLeagueService>();

            kernel.Bind<IPlayerChampionRankedStatsRepository>().To<PlayerChampionRankedStatsRepository>();
            kernel.Bind<IPlayerChampionRankedStatsService>().To<PlayerChampionRankedStatsService>();

            kernel.Bind<IRunePageRepository>().To<RunePageRepository>();
            kernel.Bind<IRunePageService>().To<RunePageService>();

            kernel.Bind<IMasteryPageRepository>().To<MasteryPageRepository>();
            kernel.Bind<IMasteryPageService>().To<MasteryPageService>();

            // Match
            kernel.Bind<IMatchDataRepository>().To<MatchDataRepository>();
            kernel.Bind<IMatchService>().To<MatchService>();

            kernel.Bind<IMatchDataParticipantRepository>().To<MatchDataParticipantRepository>();
            kernel.Bind<IMatchDataParticipantService>().To<MatchDataParticipantService>();

            kernel.Bind<IMatchDataParticipantStatsRepository>().To<MatchDataParticipantStatsRepository>();
            kernel.Bind<IMatchDataParticipantStatsService>().To<MatchDataParticipantStatsService>();

            kernel.Bind<IMatchDataTeamRepository>().To<MatchDataTeamRepository>();
            kernel.Bind<IMatchDataTeamService>().To<MatchDataTeamService>();

            kernel.Bind<IRankedMatchToProcessRepository>().To<RankedMatchToProcessRepository>();
            kernel.Bind<IRankedMatchToProcessService>().To<RankedMatchToProcessService>();

        }        
    }
}
