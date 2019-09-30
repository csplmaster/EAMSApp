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
    public class RankMasterRepository : Repository<RankMaster>, IRankMasterRepository
    {
        public RankMasterRepository(DbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetRanks()
        {
            List<SelectListItem> Ranks = EAMSContext.RankMstrs
                    .OrderBy(n => n.Seniority)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.RankId.ToString(),
                            Text = n.RankName
                        }).ToList();
            var statetip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Rank ---"
            };
            Ranks.Insert(0, statetip);
            return new SelectList(Ranks, "Value", "Text");
        }
        public IEnumerable<SelectListItem> GetCustRanks(string Type, string Service)
        {
            List<SelectListItem> Ranks = EAMSContext.RankMstrs
                .Where(w => w.RankType == Type & w.Service == Service)
                    .OrderByDescending(n => n.Seniority) 
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.RankId.ToString(),
                            Text = n.RankName
                        }).ToList();
            var statetip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Rank ---"
            };
            Ranks.Insert(0, statetip);
            return new SelectList(Ranks, "Value", "Text");
        }

        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }

        //public IEnumerable<SelectListItem> GetRanks()
        //{
        //    throw new NotImplementedException();
        //}
    }
}