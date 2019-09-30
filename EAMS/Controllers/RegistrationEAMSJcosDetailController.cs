using AutoMapper;
using EAMS.DB_Contexts;
using EAMS.Persistence;
using EAMS.View_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAMS.CustomFilters;
using EAMS.Models;


namespace EAMS.Controllers
{
    public class RegistrationEAMSJcosDetailController : Controller
    {
        // GET: RegistrationEAMSJcosDetail
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var EAMSJCOs = unitOfWork.RegEAMSJCOs.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RegistrationEAMSJco, RegEAMSJcoIndex>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<RegistrationEAMSJco>, IEnumerable<RegEAMSJcoIndex>>(EAMSJCOs);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: RegistrationEAMSJcosDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationEAMSJcosDetail/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                ViewBag.CStates = unitOfWork.StateMasters.GetStates();
                ViewBag.PStates = unitOfWork.StateMasters.GetStates();
                ViewBag.Qualifications = unitOfWork.QualificationMasters.GetQualifications();
                ViewBag.Corp = unitOfWork.CorpMasters.GetCorps();
                ViewBag.Trades = unitOfWork.TradeMasters.GetTrades();
                ViewData["SelectedCityC"] = string.Empty;
                ViewData["SelectedCityP"] = string.Empty;
                ViewData["SelectedRankID"] = string.Empty;
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: RegistrationEAMSJcosDetail/Create
        [HttpPost]
        public ActionResult Create(RegEAMSJcoCreate objEAMSJcoCr)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RegEAMSJcoCreate, RegistrationEAMSJco>();
                    });
                    IMapper mapper = config.CreateMapper();
                    RegistrationEAMSJco CreateDto = mapper.Map<RegEAMSJcoCreate, RegistrationEAMSJco>(objEAMSJcoCr);
                    unitOfWork.RegEAMSJCOs.Add(CreateDto);                    
                    ViewData["SelectedCityC"] = objEAMSJcoCr.CCityId;
                    ViewData["SelectedCityP"] = objEAMSJcoCr.PCityId;
                    ViewData["SelectedRankID"] = objEAMSJcoCr.Ranks;
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationEAMSJcosDetail/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var JCOEAMS = unitOfWork.RegEAMSJCOs.Get(id);
                unitOfWork.Complete();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RegistrationEAMSJco, RegEAMSJcoUpdate>();
                });
                IMapper mapper = config.CreateMapper();
                RegEAMSJcoUpdate UpdateDto = mapper.Map<RegistrationEAMSJco, RegEAMSJcoUpdate>(JCOEAMS);
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                ViewData["SelectedCityC"] = JCOEAMS.CCityId;
                ViewData["SelectedCityP"] = JCOEAMS.PCityId;
                return View(UpdateDto);
            }
        }

        // POST: RegistrationEAMSJcosDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(RegEAMSJcoUpdate objEAMSJCOUp)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RegEAMSJcoUpdate, RegistrationEAMSJco>();
                    });
                    IMapper mapper = config.CreateMapper();
                    RegistrationEAMSJco UpdateDto = mapper.Map<RegEAMSJcoUpdate, RegistrationEAMSJco>(objEAMSJCOUp);
                    unitOfWork.RegEAMSJCOs.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult ExcelFileUpload(RegistrationEAMSJcoVM objEAMSJco)
        //{
        //    foreach (HttpPostedFileBase file in objEAMSJco.ROfilesPath)
        //    {
        //        if (file != null)
        //        {
        //            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
        //            string filepath = "/CV/" + filename;
        //            file.SaveAs(Path.Combine(Server.MapPath("/CV"), filename));
        //        }
        //    }

        //    return RedirectToAction("ExcelFileUpload");
        //}

        // GET: RegistrationEAMSJcosDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationEAMSJcosDetail/Delete/5
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
                var jobpostsdata = unitOfWork.RankMasters.GetCustRanks("JCOOR", ServiceType);
                //ViewBag.Rank = unitOfWork.RankMasters.GetCustRanks("JCOOR","Army");
                unitOfWork.Complete();
                return Json(jobpostsdata, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCity(long stateid)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var citydata = unitOfWork.CityMasters.GetCitiesByStateId(stateid);
                unitOfWork.Complete();
                return Json(citydata, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCity1(long stateid)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var cityP = unitOfWork.CityMasters.GetCitiesByStateId(stateid);
                unitOfWork.Complete();
                return Json(cityP, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var modelDataById = unitOfWork.RegEAMSJCOs.Get(id);
                if (modelDataById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    unitOfWork.RegEAMSJCOs.Remove(modelDataById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }
    }
}
