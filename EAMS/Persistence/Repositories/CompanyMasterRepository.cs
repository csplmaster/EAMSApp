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
    public class CompanyMasterRepository : Repository<CompanyMaster>, ICompanyMasterRepository
    {
        public CompanyMasterRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetCompanies()
        {
            List<SelectListItem> companies = EAMSContext.CompanyMstrs
                    .OrderBy(n => n.CompanyName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.CompanyId.ToString(),
                            Text = n.CompanyName
                        }).ToList();
            var cmpnytip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Employer ---"
            };
            companies.Insert(0, cmpnytip);
            return new SelectList(companies, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}