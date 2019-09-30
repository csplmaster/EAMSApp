using AutoMapper;
using EAMS.DB_Contexts;
using EAMS.Models;
using EAMS.Persistence;
using EAMS.View_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EAMS.Controllers
{
    public class SponsorDataDetailsController : Controller
    {
        // GET: SponsorDataDetails
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sponsrdata = unitOfWork.SponsorDatas.GetAll();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SponsorData, SponsorDataIndexVM>();
                });
                IMapper mapper = config.CreateMapper();
                var indexDto = mapper.Map<IEnumerable<SponsorData>, IEnumerable<SponsorDataIndexVM>>(sponsrdata);
                unitOfWork.Complete();
                return View(indexDto);
            }
        }

        // GET: SponsorDataDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SponsorDataDetails/Create
        public ActionResult Create()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                //ViewBag.Esmdata = unitOfWork.ESMDetails.GetEsmOffrByVacancy(vacancyId);
                List<SelectList> drop = new List<SelectList>
                {
                };
                ViewBag.MyDrop = drop;
                ViewData["SelectedEsm"] = string.Empty;
                //ViewBag.Vacancies = unitOfWork.VacancyMasters.GetPostsByCompanyId();
                unitOfWork.Complete();
                return View();
            }
        }

        // POST: SponsorDataDetails/Create
        [HttpPost]
        public ActionResult Create(SponsorDataCreateVM objSponCrtVm, int[] SelChkEsmIds)
        {
            try
            {
                using (var unitOfWork = new UnitWork1(new EAMSContext()))
                {
                    if (SelChkEsmIds != null)
                    {
                        objSponCrtVm.iESMOffrDetails = new List<ESMOfficersDetail>();
                        foreach (var esmId in SelChkEsmIds)
                        {
                            var esmIdToAdd = unitOfWork.ESMDetails.SingleOrDefault(x => x.EsmId == esmId);
                            objSponCrtVm.iESMOffrDetails.Add(esmIdToAdd);
                        }
                    }
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<SponsorDataCreateVM, SponsorData>();
                    });
                    IMapper mapper = config.CreateMapper();
                    SponsorData CreateDto = mapper.Map<SponsorDataCreateVM, SponsorData>(objSponCrtVm);
                    unitOfWork.SponsorDatas.Add(CreateDto);
                    //ViewData["SelectedOrg"] = objSponCrtVm.ComapnyId;
                    //ViewData["Vacancy"] = objSponCrtVm.VacancyId;
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SponsorDataDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SponsorDataDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SponsorDataDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SponsorDataDetails/Delete/5
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
        [HttpPost]
        public JsonResult GetEAMSDetail(long vacancyId, string PersonType)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                if (PersonType == "O")
                {
                    //var esmdata = unitOfWork.ESMDetails.GetEsmOffrByVacancy(vacancyId); EmsVacancyData
                    var esmdata1 = unitOfWork.ESMDetails.Find(x => x.VacancyId == vacancyId).ToList();
                    List<EmsVacancyData> esmdata = new List<EmsVacancyData>();
                    foreach(var esm in esmdata1)
                    {
                        EmsVacancyData objesm = new EmsVacancyData();
                        objesm.EsmId = esm.EsmId;
                        objesm.ServiceNo = esm.ServiceNo;
                        objesm.Name = esm.Name;
                        objesm.DateofBirth = esm.DateofBirth;
                        objesm.RankName = esm.Ranks.RankName.ToString();
                        esmdata.Add(objesm);
                    }

                    unitOfWork.Complete();
                    return Json(esmdata, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var esmdata1 = unitOfWork.ESMJcoDetails.Find(x => x.VacancyId == vacancyId).ToList();
                    List<EmsVacancyData> esmdata = new List<EmsVacancyData>();
                    foreach (var esm in esmdata1)
                    {
                        EmsVacancyData objesm = new EmsVacancyData();
                        objesm.EsmId = esm.EsmId;
                        objesm.ServiceNo = esm.ServiceNo;
                        objesm.Name = esm.Name;
                        objesm.DateofBirth = esm.DateofBirth;
                        objesm.RankName = esm.Ranks.RankName.ToString();
                        esmdata.Add(objesm);
                    }

                    unitOfWork.Complete();
                    return Json(esmdata, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult GetEAMSDetail2(long vacancyId)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var esmdata = unitOfWork.ESMDetails.GetEsmOffrByVacancy(vacancyId);
                unitOfWork.Complete();
                return Json(esmdata, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteOnConfirm(int id)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var modelDataById = unitOfWork.SponsorDatas.Get(id);
                if (modelDataById == null)
                {
                    return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    unitOfWork.SponsorDatas.Remove(modelDataById);
                    unitOfWork.Complete();
                    return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
                }

            }
        }

    }
}
