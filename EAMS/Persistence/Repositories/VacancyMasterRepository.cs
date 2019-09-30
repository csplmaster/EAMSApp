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
    public class VacancyMasterRepository : Repository<VacancyMaster>, IVacancyMasterRepository
    {
        public VacancyMasterRepository(DbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetPost()
        {
            List<SelectListItem> Posts = EAMSContext.VacancyMstrs
                    .OrderBy(n => n.VacancyCode)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.VacancyId.ToString(),
                            Text = "(" + n.VacancyCode + ")" + n.PostName
                        }).ToList();
            var cmpnytip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Post ---"
            };
            Posts.Insert(0, cmpnytip);
            return new SelectList(Posts, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetPostsByCompanyId(long companyid)
        {
            List<SelectListItem> jobposts = EAMSContext.VacancyMstrs
                .Where(n => n.CompanyId == companyid)
                    .OrderBy(n => n.PostName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.VacancyId.ToString(),
                            Text = n.PostName
                        }).ToList();
            //var citytip = new SelectListItem()
            //{
            //    Value = null,
            //    Text = "--- select City ---"
            //};
            //cities.Insert(0, citytip);
            return new SelectList(jobposts, "Value", "Text");
        }
        
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}