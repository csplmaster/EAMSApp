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
    public class NACPrincpalEmployerJCOController : Controller
    {
        // GET: NACPrincpalEmployerJCO
        
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Post = unitOfWork.VacancyMasters.GetPost();
                //var JcoDtls = unitOfWork.ESMJcoDetails.GetAll();
                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<ESMJcoORsDetail, ESMJcoIndexVM>();
                //});
                //IMapper mapper = config.CreateMapper();
                //var indexDto = mapper.Map<IEnumerable<ESMJcoORsDetail>, IEnumerable<ESMJcoIndexVM>>(JcoDtls);
                //unitOfWork.Complete();
                //return View(indexDto);
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(VacancyMaster vacancy, string txtLetter)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Post = unitOfWork.VacancyMasters.GetPost();
                var selectedItem = unitOfWork.VacancyMasters.Find((p => p.PostName == vacancy.VacancyId.ToString()));
                if (selectedItem != null)
                {
                    ViewBag.PostName = selectedItem;
                    ViewBag.Letter = txtLetter.ToString();
                }
                return View(vacancy);
            }
        }

        public ActionResult Fetch(VacancyMaster vacancy)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Post = unitOfWork.VacancyMasters.GetPost();
                var selectedItem = unitOfWork.VacancyMasters.Find((p => p.PostName == vacancy.VacancyId.ToString()));
                if (selectedItem != null)
                {                    
                    ViewBag.PostName = selectedItem;
                }
                return View(vacancy);
            }
        }
    }
}