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
    public class CorpMasterRepository : Repository<CorpMaster>, ICorpMasterRepository
    {
        public CorpMasterRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetCorps()
        {
            List<SelectListItem> corps = EAMSContext.CorpMstrs
                .OrderBy(n => n.CorpName)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CorpId.ToString(),
                    Text = n.CorpName
                }).ToList();
            var drptip = new SelectListItem()
            {
                Value = null,
                Text = "--Select Corp--"
            };
            corps.Insert(0, drptip);
            return new SelectList(corps, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}