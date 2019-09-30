using EAMS.Core.IRepositories;
using EAMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using EAMS.DB_Contexts;

namespace EAMS.Persistence.Repositories
{
    public class CityMasterRepository : Repository<CityMaster>, ICityMasterRepository
    {
        public CityMasterRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetCitiesByStateId(long stateid)
        {
            List<SelectListItem> cities = EAMSContext.CityMstrs
                .Where(n => n.StateId == stateid)
                    .OrderBy(n => n.CityName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.CityId.ToString(),
                            Text = n.CityName
                        }).ToList();
            var citytip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select City ---"
            };
            cities.Insert(0, citytip);
            return new SelectList(cities, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}