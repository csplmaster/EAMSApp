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
    public class WeeklyDataOffrsController : Controller
    {
        // GET: WeeklyDataOffrs
        [EnableJsReport()]
        public ActionResult Index()
        {
            ViewBag.Fdate = "01 Aug 2019";//Convert.ToDateTime(fromDate).ToString("dd MMM yyyy");
            ViewBag.Tdate = "31 Aug 2019"; //Convert.ToDateTime(toDate).ToString("dd MMM yyyy");
            //using (var unitOfWork = new UnitWork1(new EAMSContext()))
            //{
            //    var OffrDtls = unitOfWork.SponsorDatas.GetAll();
            //    var config = new MapperConfiguration(cfg =>
            //    {
            //        cfg.CreateMap<SponsorData, SponsorDataIndexVM>();
            //    });
            //    IMapper mapper = config.CreateMapper();
            //    //var indexDto = mapper.Map<IEnumerable<SponsorData>, IEnumerable<SponsorDataIndexVM>>(OffrDtls);
            //    //unitOfWork.Complete();

            //}
            return View();
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