using System;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using EAMS.Persistence;
using EAMS.DB_Contexts;
using EAMS.View_Models;
using AutoMapper;
using EAMS.Models;
using System.Collections.Generic;

namespace EAMS.Controllers
{
    public class OutcomeDetailsController : Controller
    {
        // GET: OutcomeDetails
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var Outcomes = unitOfWork.OutcomeDatas.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OutcomeData, OutcomeDataIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<OutcomeData>, IEnumerable<OutcomeDataIndexVM>>(Outcomes);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: OutcomeDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OutcomeDetails/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                //ViewBag.Vacancies = unitOfWork.VacancyMasters.GetPostsByCompanyId();
                //ViewBag.Easm = unitOfWork.ESMDetails.GetESMs();
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: OutcomeDetails/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OutcomeDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OutcomeDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OutcomeDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OutcomeDetails/Delete/5
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

        public JsonResult GetJobPosts(long companyid)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var jobpostsdata = unitOfWork.VacancyMasters.GetPostsByCompanyId(companyid);
                unitOfWork.Complete();
                return Json(jobpostsdata, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEamsDatas(long VacancyId)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var Eamsdata = unitOfWork.ESMDetails.GetAll();
                unitOfWork.Complete();
                return Json(Eamsdata, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GetEAMSDetail(long vacancyId)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                //var esmdata = unitOfWork.ESMDetails.GetEsmOffrByVacancy(vacancyId); EmsVacancyData
                var esmdata1 = unitOfWork.ESMDetails.Find(x => x.VacancyId == vacancyId);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ESMOfficersDetail, EmsVacancyData>();
                });
                IMapper mapper = config.CreateMapper();
                var esmdata = mapper.Map<IEnumerable<ESMOfficersDetail>, IEnumerable<EmsVacancyData>>(esmdata1);


                unitOfWork.Complete();
                return Json(esmdata, JsonRequestBehavior.AllowGet);
            }
        }
    }
}