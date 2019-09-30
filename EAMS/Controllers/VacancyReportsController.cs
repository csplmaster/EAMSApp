using AutoMapper;
using EAMS.DB_Contexts;
using EAMS.Models;
using EAMS.Persistence;
using EAMS.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EAMS.Controllers
{
    public class VacancyReportsController : Controller
    {
        // GET: VacancyReports
        public ActionResult JobOpportunitiesList()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var vcyMstr = unitOfWork.VacancyMasters.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VacancyMaster, JobOpporOffcrRptVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<VacancyMaster>, IEnumerable<JobOpporOffcrRptVM>>(vcyMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }
        [HttpPost]
        public ActionResult JobOpportunitiesList(int a)
        {
            return View();
        }
    }
}