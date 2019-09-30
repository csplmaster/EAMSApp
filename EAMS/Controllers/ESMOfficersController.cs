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
    public class ESMOfficersController : Controller
    {
        // GET: ESMOfficers
        [HttpGet]
        public ViewResult Index()
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

        #region IndexGrid Region
        [HttpGet]
        public PartialViewResult IndexGrid()
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
                return PartialView("_IndexGrid", indexDto);
            }
            // Only grid query values will be available here.
            //return PartialView("_IndexGrid", repository.GetPeople());
        }
        #endregion

        // GET: ESMOfficers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ESMOfficers/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.Qualification = unitOfWork.QualificationMasters.GetQualifications();
                ViewBag.Rank = unitOfWork.RankMasters.GetRanks();
                ViewBag.sainik = unitOfWork.Sainikboards.GetSainikboard();
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: ESMOfficers/Create
        [HttpPost]
        public ActionResult Create(ESMDetailsCrtVM objESMDtlVM)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ESMDetailsCrtVM, ESMOfficersDetail>();
                    });
                    IMapper mapper = config.CreateMapper();
                    ESMOfficersDetail CreateDto = mapper.Map<ESMDetailsCrtVM, ESMOfficersDetail>(objESMDtlVM);
                    unitOfWork.ESMDetails.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: ESMOfficers/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var emsoffrDtls = unitOfWork.ESMDetails.Get(id);
                unitOfWork.Complete();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESMOfficersDetail, ESMDetailsUpVM>();
                });
                IMapper mapper = config.CreateMapper();
                ESMDetailsUpVM UpdateDto = mapper.Map<ESMOfficersDetail, ESMDetailsUpVM>(emsoffrDtls);
                
                return View(UpdateDto);
            }
        }

        // POST: ESMOfficers/Edit/5
        [HttpPost]
        public ActionResult Edit(ESMDetailsUpVM objEsmDtlUpVM)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ESMDetailsUpVM, ESMOfficersDetail>();
                    });
                    IMapper mapper = config.CreateMapper();
                    ESMOfficersDetail UpdateDto = mapper.Map<ESMDetailsUpVM, ESMOfficersDetail>(objEsmDtlUpVM);
                    unitOfWork.ESMDetails.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ESMOfficers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ESMOfficers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetRanks(string ServiceType)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var ranksdata = unitOfWork.RankMasters.GetCustRanks("Officer", ServiceType);
                unitOfWork.Complete();
                return Json(ranksdata, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetJobPosts(long companyid)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var jobpostsdata = unitOfWork.VacancyMasters.GetPostsByCompanyId(companyid);
                unitOfWork.Complete();
                return Json(jobpostsdata, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
