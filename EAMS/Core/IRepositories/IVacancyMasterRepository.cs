using EAMS.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EAMS.Core.IRepositories
{
    public interface IVacancyMasterRepository : IRepository<VacancyMaster>
    {
        IEnumerable<SelectListItem> GetPostsByCompanyId(long companyid);
        IEnumerable<SelectListItem> GetPost();
    }
}
