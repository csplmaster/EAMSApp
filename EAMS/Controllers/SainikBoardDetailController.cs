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
    public class SainikBoardDetailController : Controller
    {
        //GET: SainikBoardDetail
        public ActionResult ViewAll()
        {
            return View();
        }

        // GET: SainikBoardDetail
        [HttpGet]
        public ViewResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sainik = unitOfWork.Sainikboards.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SainikBoardDetails, SainikBoardIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<SainikBoardDetails>, IEnumerable<SainikBoardIndexVM>>(sainik);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: SainikBoardDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SainikBoardDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SainikBoardDetail/Create
        [HttpPost]
        public ActionResult Create(SainikBoardCreateVM objSainikCreate)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SainikBoardCreateVM, SainikBoardDetails>();
                    });
                    IMapper mapper = config.CreateMapper();
                    SainikBoardDetails CreateDto = mapper.Map<SainikBoardCreateVM, SainikBoardDetails>(objSainikCreate);
                    unitOfWork.Sainikboards.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: SainikBoardDetail/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sainik = unitOfWork.Sainikboards.Get(id);
                unitOfWork.Complete();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SainikBoardDetails, SainikBoardUpdtVM>();
                });
                IMapper mapper = config.CreateMapper();
                SainikBoardUpdtVM UpdateDto = mapper.Map<SainikBoardDetails, SainikBoardUpdtVM>(sainik);

                return View(UpdateDto);
            }
        }

        // POST: SainikBoardDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(SainikBoardUpdtVM objsainikUpdate)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SainikBoardUpdtVM, SainikBoardDetails>();
                    });
                    IMapper mapper = config.CreateMapper();
                    SainikBoardDetails UpdateDto = mapper.Map<SainikBoardUpdtVM, SainikBoardDetails>(objsainikUpdate);
                    //throw new System.NullReferenceException("Exception Occurred Yup");
                    unitOfWork.Sainikboards.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            finally { }
        }

        // GET: SainikBoardDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SainikBoardDetail/Delete/5
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
    }
}
