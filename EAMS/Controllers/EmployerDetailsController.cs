using AutoMapper;
using EAMS.CustomFilters;
using EAMS.DB_Contexts;
using EAMS.Models;
using EAMS.Persistence;
using EAMS.View_Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EAMS.Controllers
{
    public class EmployerDetailsController : Controller
    {
        // GET: EmployerDetails
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var emplyrDtls = unitOfWork.EmployerDetails.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EmployerDetails, EmployerDetailsIndxVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<EmployerDetails>, IEnumerable<EmployerDetailsIndxVM>>(emplyrDtls);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: EmployerDetails/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                //Parallel.Invoke(() =>
                //{
                //    ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                //},
                //() =>
                //{
                //    ViewBag.States = unitOfWork.StateMasters.GetStates();
                //}
                //);
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                ViewData["SelectedCity"] = string.Empty;
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: EmployerDetails/Create
        [HttpPost]
        public ActionResult Create(EmployerDetailsCrtVM objEmplyrDtlCVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<EmployerDetailsCrtVM, EmployerDetails>();
                    });
                    IMapper mapper = config.CreateMapper();
                    EmployerDetails CreateDto = mapper.Map<EmployerDetailsCrtVM, EmployerDetails>(objEmplyrDtlCVm);
                    unitOfWork.EmployerDetails.Add(CreateDto);
                    ViewData["SelectedCity"] = objEmplyrDtlCVm.CityId;
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployerDetails/Edit/5
        //[EncryptedActionParameter]
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //int id1 = (int)id;
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                //int id=5;
                var emplyrDtls = unitOfWork.EmployerDetails.Get(id);
                unitOfWork.Complete();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EmployerDetails, EmployerDetailsUpVM>();
                });
                IMapper mapper = config.CreateMapper();
                EmployerDetailsUpVM UpdateDto = mapper.Map<EmployerDetails, EmployerDetailsUpVM>(emplyrDtls);
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                //ViewBag.Cities = unitOfWork.CityMasters.GetCitiesByStateId();
                ViewData["SelectedCity"] = emplyrDtls.CityId;
                //if (UpdateDto == null)
                //{
                //    return HttpNotFound();
                //}
                return View(UpdateDto);
            }
        }

        // POST: EmployerDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployerDetailsUpVM objEmplyrDtlUpVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<EmployerDetailsUpVM, EmployerDetails>();
                    });
                    IMapper mapper = config.CreateMapper();
                    EmployerDetails UpdateDto = mapper.Map<EmployerDetailsUpVM, EmployerDetails>(objEmplyrDtlUpVm);
                    unitOfWork.EmployerDetails.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployerDetails/Delete/5
        [HttpPost]
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var vcyById = unitOfWork.VacancyMasters.Get(id);
                if (vcyById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //unitOfWork.VacancyMasters.Remove(vcyById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }
        //public JsonResult GetCompany(string WorkTypeID)
        //{
        //    var plandata = objPlan.GetPlanByWorkTypeID(WorkTypeID);
        //    return Json(plandata, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetState(string WorkTypeID)
        //{
        //    var plandata = GetState.GetPlanByWorkTypeID(WorkTypeID);
        //    return Json(plandata, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetCity(long stateId)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                //ViewBag.Cities = unitOfWork.CityMasters.GetCitiesByStateId();
                //ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                var citydata = unitOfWork.CityMasters.GetCitiesByStateId(stateId);
                unitOfWork.Complete();
                return Json(citydata, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
