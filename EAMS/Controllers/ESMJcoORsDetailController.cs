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
    public class ESMJcoORsDetailController : Controller
    {
        // GET: ESMJcoORsDetail
        public ViewResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var OffrDtls = unitOfWork.ESMJcoDetails.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESMJcoORsDetail, ESMJcoIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<ESMJcoORsDetail>, IEnumerable<ESMJcoIndexVM>>(OffrDtls);
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
                var OffrDtls = unitOfWork.ESMJcoDetails.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESMJcoORsDetail, ESMJcoIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<ESMJcoORsDetail>, IEnumerable<ESMJcoIndexVM>>(OffrDtls);
                unitOfWork.Complete();
                return PartialView("_IndexGrid", indexDto);
            }
            // Only grid query values will be available here.
            //return PartialView("_IndexGrid", repository.GetPeople());
        }
        #endregion

        // GET: ESMJcoORsDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ESMJcoORsDetail/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.Qualification = unitOfWork.QualificationMasters.GetQualifications();
                ViewBag.sainik = unitOfWork.Sainikboards.GetSainikboard();
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: ESMJcoORsDetail/Create
        [HttpPost]
        public ActionResult Create(ESMJcoCrtVM objESMjcoDtlVM)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ESMJcoCrtVM, ESMJcoORsDetail>();
                    });
                    IMapper mapper = config.CreateMapper();
                    ESMJcoORsDetail CreateDto = mapper.Map<ESMJcoCrtVM, ESMJcoORsDetail>(objESMjcoDtlVM);
                    unitOfWork.ESMJcoDetails.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ESMJcoORsDetail/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var emsoffrDtls = unitOfWork.ESMJcoDetails.Get(id);
                unitOfWork.Complete();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESMJcoORsDetail, ESMJcoUpVM>();
                });
                IMapper mapper = config.CreateMapper();
                ESMJcoUpVM UpdateDto = mapper.Map<ESMJcoORsDetail, ESMJcoUpVM>(emsoffrDtls);

                return View(UpdateDto);
            }
        }

        // POST: ESMJcoORsDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(ESMJcoUpVM objEsmDtlUpVM)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ESMJcoUpVM, ESMJcoORsDetail>();
                    });
                    IMapper mapper = config.CreateMapper();
                    ESMJcoORsDetail UpdateDto = mapper.Map<ESMJcoUpVM, ESMJcoORsDetail>(objEsmDtlUpVM);
                    unitOfWork.ESMJcoDetails.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ESMJcoORsDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ESMJcoORsDetail/Delete/5
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

        [HttpGet]
        public ActionResult GetSponsordata()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                var OffrDtls = unitOfWork.ESMJcoDetails.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESMJcoORsDetail, ESMJcoIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<ESMJcoORsDetail>, IEnumerable<ESMJcoIndexVM>>(OffrDtls);
                unitOfWork.Complete();
                return View(indexDto);
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
        public JsonResult GetRanks(string ServiceType)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var jobpostsdata = unitOfWork.RankMasters.GetCustRanks("JCOOR", ServiceType);
                //ViewBag.Rank = unitOfWork.RankMasters.GetCustRanks("JCOOR","Army");
                unitOfWork.Complete();
                return Json(jobpostsdata, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
