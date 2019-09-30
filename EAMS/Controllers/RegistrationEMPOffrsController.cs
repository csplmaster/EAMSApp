using AutoMapper;
using EAMS.DB_Contexts;
using EAMS.Models;
using EAMS.Persistence;
using EAMS.View_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EAMS.Controllers
{
    public class RegistrationEMPOffrsController : Controller
    {
        // GET: RegistrationEMPOffrs
        [HttpGet]
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {                
                var Regs = unitOfWork.Registrations.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RegistrationESMOffrs, RegsESMOffrsIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<RegistrationESMOffrs>, IEnumerable<RegsESMOffrsIndexVM>>(Regs);
                unitOfWork.Complete();
                return View(indexDto);

            }
        }

        // GET: RegistrationEMPOffrs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationEMPOffrs/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                ViewBag.Qualifications = unitOfWork.QualificationMasters.GetQualifications();
                ViewData["SelectedCityC"] = string.Empty;
                ViewData["SelectedCityP"] = string.Empty;
                ViewData["SelectedRank"] = string.Empty;
                unitOfWork.Complete();
                return View();

            }
        }

        // POST: RegistrationEMPOffrs/Create
        [HttpPost]
        public ActionResult Create(RegsESMOffrsCreateVM objRegs)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RegsESMOffrsCreateVM, RegistrationESMOffrs>();
                    });
                    IMapper mapper = config.CreateMapper();
                    RegistrationESMOffrs CreateDto = mapper.Map<RegsESMOffrsCreateVM, RegistrationESMOffrs>(objRegs);
                    unitOfWork.Registrations.Add(CreateDto);
                    ViewData["SelectedCityC"] = objRegs.CCityId;
                    ViewData["SelectedCityP"] = objRegs.PCityId;
                    ViewData["SelectedRank"] = objRegs.RankId;
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: RegistrationEMPOffrs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationEMPOffrs/Edit/5
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

        // GET: RegistrationEMPOffrs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationEMPOffrs/Delete/5
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

        public JsonResult GetCity(long stateId)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var citydata = unitOfWork.CityMasters.GetCitiesByStateId(stateId);
                unitOfWork.Complete();
                return Json(citydata, JsonRequestBehavior.AllowGet);
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
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var modelDataById = unitOfWork.Registrations.Get(id);
                if (modelDataById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    unitOfWork.Registrations.Remove(modelDataById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }

    }
}
