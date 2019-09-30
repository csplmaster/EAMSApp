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
    public class NotingSponsPBORController : Controller
    {
        // GET: NotingSponsPBOR
        [EnableJsReport()]
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sponDtls = unitOfWork.SponsorDatas.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SponsorData, SponsorDataIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<SponsorData>, IEnumerable<SponsorDataIndexVM>>(sponDtls);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }
    }
}