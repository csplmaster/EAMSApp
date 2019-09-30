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
    public class TradeMasterRepository : Repository<TradeMaster>, ITradeMasterRepository
    {
        public TradeMasterRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetTrades()
        {
            List<SelectListItem> trades = EAMSContext.TradeMstrs
                .OrderBy(n => n.TradeName)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.TradeId.ToString(),
                    Text = n.TradeName
                }).ToList();
            var drptip = new SelectListItem()
            {
                Value = null,
                Text = "--Select Trade--"
            };
            trades.Insert(0, drptip);
            return new SelectList(trades, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}