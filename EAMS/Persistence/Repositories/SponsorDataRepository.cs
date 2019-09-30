using EAMS.Core.IRepositories;
using EAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using EAMS.DB_Contexts;
namespace EAMS.Persistence.Repositories
{
    public class SponsorDataRepository : Repository<SponsorData>, ISponsorDataRepository
    {
        public SponsorDataRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<SelectListItem> GetEsmOffrByVacancy(long vacancyId)
        {
            List<SelectListItem> EsmOffrs = EAMSContext.ESMDetails
                    .OrderBy(n => n.Name)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.EsmId.ToString(),
                            Text = n.ServiceNo +" , "+n.Name+" , "+n.Ranks.RankName
                        }).ToList();
            return new SelectList(EsmOffrs, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}