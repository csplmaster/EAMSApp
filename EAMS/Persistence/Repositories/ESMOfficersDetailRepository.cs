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
    public class ESMOfficersDetailRepository : Repository<ESMOfficersDetail>, IESMOfficersDetailRepository
    {
        public ESMOfficersDetailRepository(DbContext context) : base(context)
        {

        }
        public IEnumerable<SelectListItem> GetEsmOffrByVacancy(long vacancyId)
        {
            List<SelectListItem> esmOffrs = EAMSContext.ESMDetails
                .Where(n => n.VacancyId == vacancyId)
                    .OrderBy(n => n.Name)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.EsmId.ToString(),
                            Text = n.Name + "  " + n.Ranks.RankName
                            //Text = n.ServiceNo.ToString() + "  " + n.Name.ToString() + "  " + n.Ranks.RankName.ToString()

                        }).ToList();
            return new SelectList(esmOffrs, "Value", "Text");
        }        
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}