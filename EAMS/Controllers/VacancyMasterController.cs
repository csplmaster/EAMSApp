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
    public class VacancyMasterController : Controller
    {
        // GET: VacancyMaster
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var vcyMstr = unitOfWork.VacancyMasters.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VacancyMaster, VacancyDetailsIndxVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<VacancyMaster>, IEnumerable<VacancyDetailsIndxVM>>(vcyMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: VacancyMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VacancyMaster/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                ViewBag.Qualifications = unitOfWork.QualificationMasters.GetQualifications();
                ViewBag.Grades = unitOfWork.GradeMasters.GetGrades();
                ViewData["SelectedCity"] = string.Empty;
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: VacancyMaster/Create
        [HttpPost]
        public ActionResult Create(VacancyDetailsCrtVM objVncyMstrCVm, int[] SelDesQualificationIds, int[] SelEssQualificationIds) //selectedQualification
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    if (SelDesQualificationIds != null)
                    {
                        objVncyMstrCVm.iQualificationDesirables = new List<QualificationMaster>();
                        foreach (var qualfy in SelDesQualificationIds)
                        {
                            //var qualfyToAdd = unitOfWork.QualificationMasters.SingleOrDefault(x => x.QualificationId == int.Parse(qualfy));
                            var qualfyToAdd = unitOfWork.QualificationMasters.SingleOrDefault(x => x.QualificationId == qualfy);
                            objVncyMstrCVm.iQualificationDesirables.Add(qualfyToAdd);
                        }
                    }
                    if (SelEssQualificationIds != null)
                    {
                        objVncyMstrCVm.iQualificationEssentials = new List<QualificationMaster>();
                        foreach (var qualfy in SelEssQualificationIds)
                        {
                            var qualfyToAdd = unitOfWork.QualificationMasters.SingleOrDefault(x => x.QualificationId == qualfy);
                            objVncyMstrCVm.iQualificationEssentials.Add(qualfyToAdd);
                        }
                    }

                    if (ModelState.IsValid || !ModelState.IsValid)
                    {
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<VacancyDetailsCrtVM, VacancyMaster>();
                        });
                        IMapper mapper = config.CreateMapper();
                        VacancyMaster CreateDto = mapper.Map<VacancyDetailsCrtVM, VacancyMaster>(objVncyMstrCVm);
                        unitOfWork.VacancyMasters.Add(CreateDto);
                        
                        unitOfWork.Complete();
                        //return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: VacancyMaster/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var vcyMstr = unitOfWork.VacancyMasters.Get(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VacancyMaster, VacancyDetailsUpVM>();
                });
                IMapper mapper = config.CreateMapper();
                VacancyDetailsUpVM UpdateDto = mapper.Map<VacancyMaster, VacancyDetailsUpVM>(vcyMstr);

                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                ViewBag.Qualifications = unitOfWork.QualificationMasters.GetQualifications();
                ViewBag.Grades = unitOfWork.GradeMasters.GetGrades();
                ViewData["SelectedCity"] = UpdateDto.CityId;

                unitOfWork.Complete();
                return View(UpdateDto);
            }
        }

        // POST: VacancyMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(VacancyDetailsUpVM objvcyMstrUpVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<VacancyDetailsUpVM, VacancyMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    VacancyMaster UpdateDto = mapper.Map<VacancyDetailsUpVM, VacancyMaster>(objvcyMstrUpVm);

                    unitOfWork.VacancyMasters.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: VacancyMaster/Delete/5
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
        public JsonResult GetCity(long stateId)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var citydata = unitOfWork.CityMasters.GetCitiesByStateId(stateId);
                unitOfWork.Complete();
                return Json(citydata, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
