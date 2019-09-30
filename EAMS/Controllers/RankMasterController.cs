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
    public class RankMasterController : Controller
    {
        // GET: RankMaster
        [HttpGet]
        public ViewResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var rnkMstr = unitOfWork.RankMasters.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RankMaster, RankMasterVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<RankMaster>, IEnumerable<RankMasterVM>>(rnkMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: RankMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RankMaster/Create
        [HttpPost]
        public ActionResult Create(RankMasterVM objrnkMstrVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RankMasterVM, RankMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    RankMaster CreateDto = mapper.Map<RankMasterVM, RankMaster>(objrnkMstrVm);
                    unitOfWork.RankMasters.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: RankMaster/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var rankMstr = unitOfWork.RankMasters.Get(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RankMasterVM, RankMaster>();
                });
                IMapper mapper = config.CreateMapper();
                RankMasterVM UpdateDto = mapper.Map<RankMaster, RankMasterVM>(rankMstr);
                unitOfWork.Complete();
                return View(UpdateDto);
            }
        }

        // POST: RankMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(RankMasterVM objrnkMstrVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RankMasterVM, RankMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    RankMaster UpdateDto = mapper.Map<RankMasterVM, RankMaster>(objrnkMstrVm);
                    unitOfWork.RankMasters.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: RankMaster/Delete/5
        [HttpPost]
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var modelDataById = unitOfWork.RankMasters.Get(id);
                if (modelDataById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    unitOfWork.RankMasters.Remove(modelDataById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }
    }
}
