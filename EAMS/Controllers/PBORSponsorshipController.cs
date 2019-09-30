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
    public class PBORSponsorshipController : Controller
    {
        // GET: PBORSponsorship
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sponsMstr = unitOfWork.PBORSpopnserships.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PBORSponsorshipDetail, PBORsponserDetailsIndxVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<PBORSponsorshipDetail>, IEnumerable<PBORsponserDetailsIndxVM>>(sponsMstr);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: PBORSponsorship/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PBORSponsorship/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: PBORSponsorship/Create
        [HttpPost]
        public ActionResult Create(PBORsponserDetailsCrtVM objPBORCrt)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<PBORsponserDetailsCrtVM, PBORSponsorshipDetail>();
                    });
                    IMapper mapper = config.CreateMapper();
                    PBORSponsorshipDetail CreateDto = mapper.Map<PBORsponserDetailsCrtVM, PBORSponsorshipDetail>(objPBORCrt);
                    unitOfWork.PBORSpopnserships.Add(CreateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PBORSponsorship/Edit/5
        public ActionResult Edit(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var PBORspons = unitOfWork.PBORSpopnserships.Get(id);
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PBORSponsorshipDetail, PBORsponserDetailsUpVM>();
                });
                IMapper mapper = config.CreateMapper();
                PBORsponserDetailsUpVM UpdateDto = mapper.Map<PBORSponsorshipDetail, PBORsponserDetailsUpVM>(PBORspons);
                unitOfWork.Complete();
                return View(UpdateDto);
            }
        }

        // POST: PBORSponsorship/Edit/5
        [HttpPost]
        public ActionResult Edit(PBORsponserDetailsUpVM objPBORSponDtlUpVM)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<PBORsponserDetailsUpVM, PBORSponsorshipDetail>();
                    });
                    IMapper mapper = config.CreateMapper();
                    PBORSponsorshipDetail UpdateDto = mapper.Map<PBORsponserDetailsUpVM, PBORSponsorshipDetail>(objPBORSponDtlUpVM);
                    unitOfWork.PBORSpopnserships.Update(UpdateDto);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PBORSponsorship/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PBORSponsorship/Delete/5
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
