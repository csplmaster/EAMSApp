using EAMS.Core.IRepositories;
using EAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EAMS.DB_Contexts;
using System.Web.Mvc;

namespace EAMS.Persistence.Repositories
{
    public class StateMasterRepository : Repository<StateMaster>, IStateMasterRepository
    {
        public StateMasterRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetStates()
        {
            List<SelectListItem> states = EAMSContext.StateMstrs
                    .OrderBy(n => n.StateName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.StateId.ToString(),
                            Text = n.StateName
                        }).ToList();
            var statetip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select State ---"
            };
            states.Insert(0, statetip);
            return new SelectList(states, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}