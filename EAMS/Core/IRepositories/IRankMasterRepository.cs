using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAMS.Models;
using System.Web.Mvc;

namespace EAMS.Core.IRepositories
{
    public interface IRankMasterRepository : IRepository<RankMaster>
    {
        IEnumerable<SelectListItem> GetRanks();
        IEnumerable<SelectListItem> GetCustRanks(string Type, string service);
    }
}
