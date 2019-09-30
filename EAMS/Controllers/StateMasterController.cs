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
    public class StateMasterController : Controller
    {
        // GET: StateMaster
        [HttpGet]
        public ViewResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var stateMstr = unitOfWork.StateMasters.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StateMaster, StateMasterVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<StateMaster>, IEnumerable<StateMasterVM>>(stateMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: StateMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateMaster/Create
        [HttpPost]
        public ActionResult Create(StateMasterVM objSttMstrVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<StateMasterVM, StateMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    StateMaster CreateDto = mapper.Map<StateMasterVM, StateMaster>(objSttMstrVm);
                    unitOfWork.StateMasters.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StateMaster/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var stateMstr = unitOfWork.StateMasters.Get(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StateMasterVM, StateMaster>();
                });
                IMapper mapper = config.CreateMapper();
                StateMasterVM UpdateDto = mapper.Map<StateMaster, StateMasterVM>(stateMstr);
                unitOfWork.Complete();
                return View(UpdateDto);
            }
        }

        // POST: StateMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(StateMasterVM objSttMstrVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<StateMasterVM, StateMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    StateMaster UpdateDto = mapper.Map<StateMasterVM, StateMaster>(objSttMstrVm);
                    unitOfWork.StateMasters.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        [HttpPost]
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var modelDataById = unitOfWork.StateMasters.Get(id);
                if (modelDataById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    unitOfWork.StateMasters.Remove(modelDataById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }
    }
}
