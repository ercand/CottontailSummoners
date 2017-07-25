using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;
using Website.Services.Interfaces;
using Website.Helpers;
using CottontailApi.Dto.Summoner;
using CottontailApi.Exceptions;

namespace Website.Services
{
    public class SummonerService : ISummonerService
    {
        ISummonerRepository _summonerRepository;
        IUnitOfWork _unitOfWork;
        CottontailApi.IRiotApiClient _riotApiClient;

        public SummonerService(ISummonerRepository summonerRepository, IUnitOfWork unitOfWork, CottontailApi.IRiotApiClient riotApiClient)
        {
            this._summonerRepository = summonerRepository;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }
        public IEnumerable<Summoner> Find(string summonersName, CottontailApi.Commons.Enums.Platform platform, bool skipUpdate = false)
        {
            return this.Find(new List<string>() { summonersName }, platform, skipUpdate);
        }

        public IEnumerable<Summoner> Find(List<string> summonersName, CottontailApi.Commons.Enums.Platform platform, bool skipUpdate = false)
        {
            DateTime utcNowDt = DateTime.UtcNow;
            List<SummonerDto> summonerNewData = new List<SummonerDto>();
            foreach (string sum in summonersName)
            {
                try
                {
                    var ts = _riotApiClient.GetSummonerByName(sum, platform);
                    summonerNewData.Add(ts);
                }
                catch (RiotApiException ex)
                {
                    Trace.WriteLine("GetSummonerByName() - errore 429");

                }
            }

            List<long> allSummonerId = summonerNewData.Select(x => x.Id).ToList();
            //        return Find(allSummonerID, region);

            //Cerco i Summoners nel database e se non presenti o out of date allora usare la call alle API
            var summonerFromDb = _summonerRepository.FindSummoner(allSummonerId, Utility.Platform.PlatformToInt(platform)).ToList();

            // Divido i summoner in tre List. Quelli Aggiornati, quelli da aggiornare e quelli non presenti nel DB
            var summonerToNotUpdate = summonerFromDb.Where(time => (utcNowDt - time.LastUpdate).TotalSeconds < 3600.0f).ToList(); // Summoner nel DB che possono essere utilizzati subito
            var summonerToSearch = allSummonerId.Where(x => !summonerFromDb.Select(riotId => riotId.RiotSummonerID).Contains(x)).ToList(); //Summoner non presenti nel DB
            var summonerToUpdate = summonerFromDb.Where(time => (utcNowDt - time.LastUpdate).TotalSeconds >= 3600.0f).ToList(); // Summoner gia presenti nel DB che devono essere aggiornati

            // Cerca i nuovi summoner e quelli da aggiornare
            var toSearch = summonerToSearch.Concat(summonerToUpdate.Select(n => n.RiotSummonerID)).ToList();


            List<Summoner> toSave = new List<Summoner>();
            List<Summoner> result = null;

            // Crea oppure aggiorna i dati dei Summoner
            if (summonerNewData.Count > 0)
            {
                foreach (var summonerNameToCreate in summonerToSearch)
                {
                    var dto = summonerNewData.Where(x => x.Id == summonerNameToCreate).Single();
                    long uid = dto.Id * 100 + Utility.Platform.PlatformToInt(platform);
                    string viewsInfo = CreateViewsInfo(DateTime.UtcNow.Month == 1 ? 12 : DateTime.UtcNow.Month - 1, 0, DateTime.UtcNow.Month, 1);
                    toSave.Add(new Summoner((int)dto.Id, dto.Name, dto.AccountId, dto.ProfileIconId, dto.RevisionDate, (int)dto.Level, Utility.Platform.PlatformToInt(platform), 0, viewsInfo, utcNowDt, uid));
                }
                foreach (var sumDto in summonerToUpdate)
                {
                    // Update score and views info
                    int newScore = sumDto.Score;
                    string newViewsInfo = sumDto.Viewsinfo;
                    UpdateScoreAndViews(ref newViewsInfo, ref newScore);

                    var dto = summonerNewData.Where(x => x.Id == sumDto.RiotSummonerID).Single();
                    sumDto.RiotSummonerID = (int)dto.Id;
                    sumDto.Name = dto.Name;
                    sumDto.AccountId = dto.AccountId;
                    sumDto.ProfileIconId = dto.ProfileIconId;
                    sumDto.RevisionDate = dto.RevisionDate;
                    sumDto.Level = (int)dto.Level;
                    sumDto.Score = newScore;
                    sumDto.Viewsinfo = newViewsInfo;
                    sumDto.LastUpdate = utcNowDt;
                    toSave.Add(sumDto);

                    toSave.Add(sumDto);
                }

                // Crea la list aggiornata di tutti i summoner
                result = summonerToNotUpdate.Concat(toSave).ToList();
                this.Save(toSave);
            }

            return result;
        }

        public IEnumerable<Summoner> Find(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform, bool skipUpdate = false)
        {
            return Find(new List<long>() { riotSummonerId }, platform, skipUpdate);
        }
        public IEnumerable<Summoner> Find(List<long> riotSummonerId, CottontailApi.Commons.Enums.Platform platform, bool skipUpdate = false)
        {
            DateTime utcNowDt = DateTime.UtcNow;
            float skipFactor = skipUpdate == true ? 10000 : 1;
            //Cerco i Summoners nel database e se non presenti o out of date allora usare la call alle API
            var summonerFromDb = _summonerRepository.FindSummoner(riotSummonerId, Utility.Platform.PlatformToInt(platform)).ToList();

            // Divido i summoner in tre List. Quelli Aggiornati, quelli da aggiornare e quelli non presenti nel DB
            var summonerToNotUpdate = summonerFromDb.Where(time => (utcNowDt - time.LastUpdate).TotalSeconds < 3600.0f * skipFactor).ToList(); // Summoner nel DB che possono essere utilizzati subito
            var summonerToSearch = riotSummonerId.Where(x => !summonerFromDb.Select(s => s.RiotSummonerID).Contains(x)).ToList(); //Summoner non presenti nel DB
            var summonerToUpdate = summonerFromDb.Where(time => (utcNowDt - time.LastUpdate).TotalSeconds >= 3600.0f * skipFactor).ToList(); // Summoner gia presenti nel DB che devono essere aggiornati

            // Cerca i nuovi summoner e quelli da aggiornare
            var toSearch = summonerToSearch.Concat(summonerToUpdate.Select(n => n.RiotSummonerID)).ToList();

            // Non ci sono summoner da cercare o da aggiornare quindi ritorno quelli trovati nel database
            if (toSearch.Count == 0)
            {
                return summonerToNotUpdate;
            }

            // Search new summoner
            List<SummonerDto> summonerNewData = new List<SummonerDto>();
            foreach (var l in toSearch)
            {
                try
                {
                    var ts = _riotApiClient.GetSummonerById(l, platform);
                    summonerNewData.Add(ts);
                }
                catch (RiotApiException ex)
                {
#warning aggiungere codice exception
                }
            }


            List<Summoner> toSave = new List<Summoner>();
            List<Summoner> result = null;

            // Crea oppure aggiorna i dati dei Summoner
            if (summonerNewData.Count > 0)
            {
                // New summoners
                foreach (var summonerToCreate in summonerToSearch)
                {
                    var dto = summonerNewData.Where(s => s.Id == summonerToCreate).Single();
                    long uid = (long)dto.Id * 100 + Utility.Platform.PlatformToInt(platform);
                    string viewsInfo = CreateViewsInfo(DateTime.UtcNow.Month == 1 ? 12 : DateTime.UtcNow.Month - 1, 0, DateTime.UtcNow.Month, 1);
                    toSave.Add(new Summoner((int)dto.Id, dto.Name, dto.AccountId, dto.ProfileIconId, dto.RevisionDate, (int)dto.Level, Utility.Platform.PlatformToInt(platform), 0, viewsInfo, utcNowDt, uid));
                }
                foreach (var sumDto in summonerToUpdate)
                {
                    // Update score and views info
                    int newScore = sumDto.Score;
                    string newViewsInfo = sumDto.Viewsinfo;
                    UpdateScoreAndViews(ref newViewsInfo, ref newScore);

                    var dto = summonerNewData.Where(s => s.Id == sumDto.RiotSummonerID).Single();
                    sumDto.RiotSummonerID = (int)dto.Id;
                    sumDto.Name = dto.Name;
                    sumDto.AccountId = dto.AccountId;
                    sumDto.ProfileIconId = dto.ProfileIconId;
                    sumDto.RevisionDate = dto.RevisionDate;
                    sumDto.Level = (int)dto.Level;
                    sumDto.Score = newScore;
                    sumDto.Viewsinfo = newViewsInfo;
                    sumDto.LastUpdate = utcNowDt;
                    toSave.Add(sumDto);
                }

                this.Save(toSave);

                // Crea la list aggiornata di tutti i summoner
                result = summonerToNotUpdate.Concat(toSave).ToList();
            }

            return result;
        }
        public void RefreshLastRanked(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform, long riotMatchId)
        {
            var s = this._summonerRepository.FindSummoner(riotSummonerId, Utility.Platform.PlatformToInt(platform));

            s.LastRankedMatchRiotId = riotMatchId;

            Save(s);
        }

        public IEnumerable<Summoner> GetAll()
        {
            return this._summonerRepository.GetAll();
        }
        public void Save(Summoner summoner)
        {
            this.Save(new List<Summoner>() { summoner });
        }
        public void Save(IEnumerable<Summoner> summoners)
        {
            foreach (var summoner in summoners)
            {
                if (summoner.ID == default(int))
                {
                    this._summonerRepository.Insert(summoner);
                    Trace.WriteLine("SummonerService.Save() Summoner aggiunto: id=" + summoner.ID + " - accountiId=" + summoner.AccountId + " - platform: " + summoner.Platform);
                }
                else
                {
                    this._summonerRepository.Update(summoner);
                    Trace.WriteLine("SummonerService.Save() Summoner update: id=" + summoner.ID + " - accountiId=" + summoner.AccountId + " - platform: " + summoner.Platform);
                }
            }
            //if (summoners.Count() >20)
            //{
            //    Thread.Sleep(5000);
            //}
            this._summonerRepository.Save();//this.unitOfWork.SaveChanges();
        }
        public void Delete(Summoner summoner) { }
        public void Delete(IList<Summoner> summoners) { }

        private bool UpdateScoreAndViews(ref string views, ref int score)
        {
            bool result = false;
            var viewsList = views.Split(':');
            var oldIntervalData = viewsList[0].Split(',');
            var currentIntervalData = viewsList[1].Split(',');

            // Old week data
            int oldInterval = Int32.Parse(oldIntervalData[0]);
            int oldIntervalViews = Int32.Parse(oldIntervalData[1]);

            // Current Week data
            int currentInterval = Int32.Parse(currentIntervalData[0]);
            int currentIntervalViews = Int32.Parse(currentIntervalData[1]);

            //
            int monthOfTheYear = DateTime.UtcNow.Month;

            // If new week
            if (currentInterval != monthOfTheYear)
            {
                views = CreateViewsInfo(currentInterval, currentIntervalViews, monthOfTheYear, 1);

                int currentIntervalDiff = currentInterval > monthOfTheYear ? 12 - currentInterval + monthOfTheYear : monthOfTheYear - currentInterval;
                int oldIntervalDiff = oldInterval > currentInterval ? 12 - oldInterval + currentInterval : currentInterval - oldInterval;

                var monthScore = currentIntervalDiff * currentIntervalViews - oldIntervalDiff * oldIntervalDiff * 0.5;

                score = score + (int)monthScore;
                result = true;
            }
            else
            {
                views = CreateViewsInfo(oldInterval, oldIntervalViews, currentInterval, ++currentIntervalViews);
            }
            return result;
        }

        private string CreateViewsInfo(int oldInterval, int oldView, int currentInterval, int currentView)
        {
            return oldInterval + "," + oldView + ":" + currentInterval + "," + currentView;
        }
    }
}