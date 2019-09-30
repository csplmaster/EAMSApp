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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMS.Controllers
{
    public class SponsDataOffrsController : Controller
    {
        // GET: SponsDataOffrs
        [EnableJsReport()]
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var OffrDtls = unitOfWork.PBORSpopnserships.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PBORSponsorshipDetail, PBORsponserDetailsIndxVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<PBORSponsorshipDetail>, IEnumerable<PBORsponserDetailsIndxVM>>(OffrDtls);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }
    }
}