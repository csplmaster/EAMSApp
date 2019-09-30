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
    public class CityMasterController : Controller
    {
        // GET: CityMaster
        [HttpGet]
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var cityMstr = unitOfWork.CityMasters.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CityMaster, CityMasterVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<CityMaster>, IEnumerable<CityMasterVM>>(cityMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: CityMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CityMaster/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: CityMaster/Create
        [HttpPost]
        public ActionResult Create(CityMasterVM objCityMstrVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CityMasterVM, CityMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    CityMaster CreateDto = mapper.Map<CityMasterVM, CityMaster>(objCityMstrVm);
                    unitOfWork.CityMasters.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CityMaster/Edit/5
        //[EncryptedActionParameter]
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var cityMstr = unitOfWork.CityMasters.Get(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CityMaster, CityMasterVM>();
                });
                IMapper mapper = config.CreateMapper();
                CityMasterVM UpdateDto = mapper.Map<CityMaster, CityMasterVM>(cityMstr);
                ViewBag.States = unitOfWork.StateMasters.GetStates();
                unitOfWork.Complete();
                return View(UpdateDto);
            }
        }

        // POST: CityMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(CityMasterVM objCityMstrVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CityMasterVM, CityMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    CityMaster UpdateDto = mapper.Map<CityMasterVM, CityMaster>(objCityMstrVm);
                    unitOfWork.CityMasters.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // POST: CityMaster/Delete/5
        [HttpPost]
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var modelDataById = unitOfWork.CityMasters.Get(id);
                if (modelDataById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    unitOfWork.CityMasters.Remove(modelDataById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }
    }
}
