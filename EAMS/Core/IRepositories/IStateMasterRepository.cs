using EAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EAMS.Core.IRepositories
{
    public interface IStateMasterRepository : IRepository<StateMaster>
    {
        IEnumerable<SelectListItem> GetStates();
    }
}
