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
    public class QualificationMasterController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var qualtnMstr = unitOfWork.QualificationMasters.GetAll().ToList();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<QualificationMaster, QualificationMasterIndxVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<QualificationMaster>, IEnumerable<QualificationMasterIndxVM>>(qualtnMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }


        // GET: QualificationMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QualificationMaster/Create
        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QualificationMasterCrtVM objQualMstr)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<QualificationMasterCrtVM, QualificationMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    QualificationMaster CreateDto = mapper.Map<QualificationMasterCrtVM, QualificationMaster>(objQualMstr);
                    unitOfWork.QualificationMasters.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: QualificationMaster/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var qualtnMstr = unitOfWork.QualificationMasters.Get(id);
                unitOfWork.Complete();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<QualificationMaster, QualificationMasterUpVM>();
                });
                IMapper mapper = config.CreateMapper();
                QualificationMasterUpVM UpdateDto = mapper.Map<QualificationMaster, QualificationMasterUpVM>(qualtnMstr);
                return View(UpdateDto);
            }
        }

        // POST: QualificationMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(QualificationMasterUpVM objCmpMstrUpVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<QualificationMasterUpVM, QualificationMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    QualificationMaster UpdateDto = mapper.Map<QualificationMasterUpVM, QualificationMaster>(objCmpMstrUpVm);
                    unitOfWork.QualificationMasters.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: QualificationMaster/Delete/5
        [HttpPost]
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var modelDataById = unitOfWork.QualificationMasters.Get(id);
                if (modelDataById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    unitOfWork.QualificationMasters.Remove(modelDataById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }
    }
}
