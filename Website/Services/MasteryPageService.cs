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
    public class MasteryPageService : IMasteryPageService
    {
        IMasteryPageRepository _masteryPageRepository;
        ISummonerService _summonerRepository;
        IUnitOfWork _unitOfWork;
        CottontailApi.IRiotApiClient _riotApiClient;

        public MasteryPageService(IMasteryPageRepository runePageRepository, ISummonerService summonerRepository, IUnitOfWork unitOfWork, CottontailApi.IRiotApiClient riotApiClient)
        {
            this._masteryPageRepository = runePageRepository;
            this._summonerRepository = summonerRepository;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }

        public IEnumerable<MasteryPage> Find(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform)
        {
            int platformInt = Utility.Platform.PlatformToInt(platform);
            DateTime utcNowDt = DateTime.UtcNow;
            var summonerIdDb = _summonerRepository.Find(riotSummonerId, platform).Single();

            var masteryFromDb = _masteryPageRepository.FindMasteryPage(riotSummonerId, platformInt).ToList();

            // Controlla l'ultimo aggiornamento, basta controllare solo una entity in quando verranno aggiornate tutte insieme
            if (masteryFromDb.Count() > 0)
            {
                if ((utcNowDt - masteryFromDb.First().LastUpdate).TotalSeconds < 3600.0f)
                {
                    return masteryFromDb;
                }
            }

            List<MasteryPage> toSave = new List<MasteryPage>();
            var newMastery = _riotApiClient.GetMasteryPagesBySummonerId(riotSummonerId, platform);
            
            foreach (var item in newMastery.Pages)
            {
                var pageInBd = masteryFromDb.Where(t => t.RiotMasteryPageID == item.Id).SingleOrDefault();
                if (pageInBd != null)
                {
                    // Update
                    pageInBd.Name = item.Name;
                    pageInBd.IsCurrent = item.Current;
                    pageInBd.MasteryCode = Utility.Mastery.ToMasteyPageCode(item.Masteries);
                    pageInBd.LastUpdate = utcNowDt;

                    toSave.Add(pageInBd);
                }
                else
                {
                    
                    MasteryPage p = new MasteryPage();

                    p.RiotMasteryPageID = (int)item.Id;
                    p.Name = item.Name;
                    p.IsCurrent = item.Current;
                    p.MasteryCode = Utility.Mastery.ToMasteyPageCode(item.Masteries);
                    p.RiotSummonerID = riotSummonerId;
                    p.Platform = platformInt;
                    p.LastUpdate = utcNowDt;
                    p.FK_SummonerID = summonerIdDb.ID;
                    p.Uid = item.Id * 100 + platformInt;

                    toSave.Add(p);
                }
            }

            Save(toSave);
            return toSave;
        }

        public IEnumerable<MasteryPage> GetAll()
        {
            return this._masteryPageRepository.GetAll();
        }
        public void Save(MasteryPage masteryPage)
        {
            this.Save(new List<MasteryPage>() { masteryPage });
        }
        public void Save(IEnumerable<MasteryPage> masteryPages)
        {
            foreach (var masteryPage in masteryPages)
            {
                if (masteryPage.ID == default(int))
                {
                    this._masteryPageRepository.Insert(masteryPage);
                }
                else
                {
                    this._masteryPageRepository.Update(masteryPage);
                }
            }

            this._masteryPageRepository.Save();//this.unitOfWork.SaveChanges();
        }
        public void Delete(MasteryPage masteryPage) { }
        public void Delete(IList<MasteryPage> masteryPages) { }
    
    }
}