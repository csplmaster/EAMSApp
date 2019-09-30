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
    public class NotingNACJCOController : Controller
    {
        // GET: NotingNACJCO
        [EnableJsReport()]
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var jcoDtls = unitOfWork.ESMJcoDetails.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESMJcoORsDetail, ESMJcoIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<ESMJcoORsDetail>, IEnumerable<ESMJcoIndexVM>>(jcoDtls);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }
    }
}