using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;
using Website.Services.Interfaces;
using Website.Helpers;

namespace Website.Services
{
    public class RunePageService : IRunePageService
    {
        IRunePageRepository _runePageRepository;
        ISummonerService _summonerRepository;
        IUnitOfWork _unitOfWork;
        CottontailApi.IRiotApiClient _riotApiClient;

        public RunePageService(IRunePageRepository runePageRepository, ISummonerService summonerRepository, IUnitOfWork unitOfWork, CottontailApi.IRiotApiClient riotApiClient)
        {
            this._runePageRepository = runePageRepository;
            this._summonerRepository = summonerRepository;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }

        public IEnumerable<RunePage> Find(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform)
        {
            int regionToInt = Utility.Platform.PlatformToInt(platform);
            DateTime utcNowDt = DateTime.UtcNow;
            var summonerIdDb = _summonerRepository.Find(riotSummonerId, platform).Single();

            var runeFromDb = _runePageRepository.FindRunePage(riotSummonerId, regionToInt).ToList();

            // Controlla l'ultimo aggiornamento, basta controllare solo una entity in quando verranno aggiornate tutte insieme
            if (runeFromDb.Count() > 0)
            {
                if ((utcNowDt - runeFromDb.First().LastUpdate).TotalSeconds < 3600.0f)
                {
                    return runeFromDb;
                }
            }

            List<RunePage> toSave = new List<RunePage>();
            var newRune = _riotApiClient.GetRunePagesBySummonerId(riotSummonerId, platform);
            var newPages = newRune.Pages;
            foreach (var item in newPages)
            {
                var pageInBD = runeFromDb.Where(t => t.IdRunePage == item.Id).SingleOrDefault();
                if (pageInBD != null)
                {
                    // Aggiorna record esistente
                    pageInBD.IsCurrent = item.Current;
                    pageInBD.Name = item.Name;
                    pageInBD.RuneCode = Utility.Rune.ToRunePageCode(item.Slots);
                    pageInBD.LastUpdate = utcNowDt;

                    toSave.Add(pageInBD);
                }
                else
                {
                    // Crea nuovo record nel DB
                    RunePage p = new RunePage();

                    p.IdRunePage = (int)item.Id;
                    p.Name = item.Name;
                    p.IsCurrent = item.Current;
                    p.RuneCode = Utility.Rune.ToRunePageCode(item.Slots);
                    p.RiotSummonerID = riotSummonerId;
                    p.Platform = regionToInt;
                    p.LastUpdate = utcNowDt;
                    p.FK_SummonerID = summonerIdDb.ID;
                    p.Uid= item.Id * 100 + regionToInt;

                    toSave.Add(p);
                }
            }

            Save(toSave);
            return toSave;
        }

        public IEnumerable<RunePage> GetAll()
        {
            return this._runePageRepository.GetAll();
        }
        public void Save(RunePage runePage)
        {
            this.Save(new List<RunePage>() { runePage });
        }
        public void Save(IEnumerable<RunePage> runePages)
        {
            foreach (var runePage in runePages)
            {
                if (runePage.ID == default(long))
                {
                    this._runePageRepository.Insert(runePage);
                }
                else
                {
                    this._runePageRepository.Update(runePage);
                }
            }

            this._runePageRepository.Save();
        }
        public void Delete(RunePage runePage) { }
        public void Delete(IList<RunePage> runePages) { }
    }
}