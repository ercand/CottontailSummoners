using Website.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class LolDatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UnitOfWork>
    {
        protected override void Seed(UnitOfWork context)
        {
        /*    var summ = new Summoner(23748066, "Ercand", 936, 1446481482000, 30, "NA", DateTime.Now);
                
            //context.Summoners.Add(summ);
            //context.SaveChanges();
            context.Set<Summoner>().Add(summ);
            context.SaveChanges();

            // Rune Page
            var sum1 = context.Set<Summoner>().Where(s => s.Name == "Ercand" && s.Region == "NA").FirstOrDefault();
            RunePage runePage = new RunePage(){IdRunePage= 222222, IsCurrent=false, Region= "NA", Name="Nome Runa", FK_SummonerID= sum1.ID, RuneCode="{0000:1}, {1111:1}"};
            context.Set<RunePage>().Add(runePage);*/
        }
    }
}