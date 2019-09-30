using AutoMapper;
using EAMS.DB_Contexts;
using EAMS.Models;
using EAMS.Persistence;
using EAMS.View_Models;
using jsreport.MVC;
using jsreport.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activities;
using System.Web;
using System.Web.Mvc;

namespace EAMS.Controllers
{
    public class WeeklyDataPBORController : Controller
    {
        // GET: WeeklyDataPBOR
        [EnableJsReport()]
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var JcoDtls = unitOfWork.PBORSpopnserships.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PBORSponsorshipDetail, PBORsponserDetailsIndxVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<PBORSponsorshipDetail>, IEnumerable<PBORsponserDetailsIndxVM>>(JcoDtls);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }
        [HttpPost]
        public ActionResult Index(DateTime fromDate, DateTime toDate)
        {
            ViewBag.Fdate = Convert.ToDateTime(fromDate).ToString("dd MMM yyyy");
            ViewBag.Tdate = Convert.ToDateTime(toDate).ToString("dd MMM yyyy");
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sponsrdata = unitOfWork.SponsorDatas.GetAll().Where(s => s.SponsorShipDate.Date >= fromDate && s.SponsorShipDate.Date <= toDate);
                ViewBag.weekly = sponsrdata;
                return View(sponsrdata);
            }
        }
    }
}