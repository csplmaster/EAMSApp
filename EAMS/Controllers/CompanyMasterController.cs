using AutoMapper;
using EAMS.CustomFilters;
using EAMS.DB_Contexts;
using EAMS.Models;
using EAMS.Persistence;
using EAMS.View_Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace EAMS.Controllers
{
    public class CompanyMasterController : Controller
    {
        // GET: CompanyMaster

        [HttpGet]
        public ViewResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var cmpMstr = unitOfWork.CompanyMasters.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CompanyMaster, CompanyMasterIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<CompanyMaster>, IEnumerable<CompanyMasterIndexVM>>(cmpMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: CompanyMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyMaster/Create
        [HttpPost]
        public ActionResult Create(CompanyMasterCreateVM objCmpMstrCVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CompanyMasterCreateVM, CompanyMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    CompanyMaster CreateDto = mapper.Map<CompanyMasterCreateVM, CompanyMaster>(objCmpMstrCVm);
                    unitOfWork.CompanyMasters.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyMaster/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var cmpMstr = unitOfWork.CompanyMasters.Get(id);
                unitOfWork.Complete();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CompanyMaster, CompanyMasterUpdateVM>();
                });
                IMapper mapper = config.CreateMapper();
                CompanyMasterUpdateVM UpdateDto = mapper.Map<CompanyMaster, CompanyMasterUpdateVM>(cmpMstr);

                return View(UpdateDto);
            }
        }

        // POST: CompanyMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(CompanyMasterUpdateVM objCmpMstrUpVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CompanyMasterUpdateVM, CompanyMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    CompanyMaster UpdateDto = mapper.Map<CompanyMasterUpdateVM, CompanyMaster>(objCmpMstrUpVm);
                    //throw new System.NullReferenceException("Exception Occurred Yup");
                    unitOfWork.CompanyMasters.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: CompanyMaster/Delete/5

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    using (var unitOfWork = new UnitWork1(new EAMSContext()))
        //    {
        //        var cmpMstr = unitOfWork.CompanyMasters.SingleOrDefault(c => c.CompanyId == id);
        //        unitOfWork.Complete();
        //        if (cmpMstr == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return Content("Hello");
        //    }
        //}
        [HttpPost]
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var modelDataById = unitOfWork.CompanyMasters.Get(id);
                if (modelDataById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    unitOfWork.CompanyMasters.Remove(modelDataById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }
    }
}
