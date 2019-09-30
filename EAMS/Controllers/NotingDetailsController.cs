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
    public class NotingDetailsController : Controller
    {
        // GET: NotingDetails
        [HttpGet]
        public ViewResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var NotingMstr = unitOfWork.Notings.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<NotingMaster, NotingIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<NotingMaster>, IEnumerable<NotingIndexVM>>(NotingMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: NotingDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotingDetails/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: NotingDetails/Create
        [HttpPost]
        public ActionResult Create(NotingCreateVM objNotingMstrCVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<NotingCreateVM, NotingMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    NotingMaster CreateDto = mapper.Map<NotingCreateVM, NotingMaster>(objNotingMstrCVm);
                    unitOfWork.Notings.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { };
        }

        // GET: NotingDetails/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var NotingMstr = unitOfWork.Notings.Get(id);
                unitOfWork.Complete();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<NotingMaster, NotingUpVM>();
                });
                IMapper mapper = config.CreateMapper();
                NotingUpVM UpdateDto = mapper.Map<NotingMaster, NotingUpVM>(NotingMstr);

                return View(UpdateDto);
            }
        }

        // POST: NotingDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(NotingUpVM objNotingMstrUpVm)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<NotingUpVM, NotingMaster>();
                    });
                    IMapper mapper = config.CreateMapper();
                    NotingMaster UpdateDto = mapper.Map<NotingUpVM, NotingMaster>(objNotingMstrUpVm);
                    unitOfWork.Notings.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: NotingDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotingDetails/Delete/5
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
    }
}
