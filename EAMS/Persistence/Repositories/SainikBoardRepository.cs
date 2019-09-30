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
    public class SainikBoardRepository : Repository<SainikBoardDetails>, ISainikBoardRepository
    {
        public SainikBoardRepository(DbContext context) : base(context)
        { 
        }

        public IEnumerable<SelectListItem> GetSainikboard()
        {
            List<SelectListItem> sainikBoards = EAMSContext.SainikBoardMasters
                    .OrderBy(n => n.Sbname)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.SbId.ToString(),
                            Text = n.Sbname
                        }).ToList();
            var listTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Sainik Board ---"
            };
            sainikBoards.Insert(0, listTip);
            return new SelectList(sainikBoards, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }

    }
}