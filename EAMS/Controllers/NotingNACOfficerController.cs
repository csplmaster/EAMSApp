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
    public class NotingNACOfficerController : Controller
    {
        // GET: NotingNACOfficer
        [EnableJsReport()]
        public ActionResult Index()
        {
           using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var OffrDtls = unitOfWork.ESMDetails.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESMOfficersDetail, ESMDetailsIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<ESMOfficersDetail>, IEnumerable<ESMDetailsIndexVM>>(OffrDtls);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }
        //[EnableJsReport(Recipe = "html-to-xlsx")]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}