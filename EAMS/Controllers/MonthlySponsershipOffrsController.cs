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
    public class MonthlySponsershipOffrsController : Controller
    {
        // GET: MonthlySponsershipOffrs
        public ActionResult Index(DateTime? MonthYear)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                //if (MonthYear == null)
                //{
                //    var esmData = unitOfWork.ESMDetails.GetAll().ToList();
                //    MonthlySponsrData(unitOfWork, esmData);
                //}
                //else
                //{
                //    var esmData = unitOfWork.ESMDetails.GetAll().Where(s => s.d.Date >= fromDate && s.SponsorShipDate.Date <= toDate);
                //    MonthlySponsrData(unitOfWork, esmData);
                //}
                var esmData = unitOfWork.ESMDetails.GetAll().ToList();
                return View();
            }
        }

        private void MonthlySponsrData(UnitWork1 unitOfWork, List<ESMOfficersDetail> esmData)
        {
            var companyData = unitOfWork.CompanyMasters.GetAll();
            var vacancyData = unitOfWork.VacancyMasters.GetAll();
            var MonthSponserOffrsRecord = from e in esmData
                                          join c in companyData on e.CompanyId equals c.CompanyId into table1
                                          from c in table1.ToList()
                                          join v in vacancyData on e.VacancyId equals v.VacancyId into table2
                                          from v in table2
                                          select new MonthlySponsershipOffrsRptVm
                                          {
                                              Companys = c,
                                              EsmOffrsDtls = e,
                                              Vacancys = v

                                          };

            var cmpnydt = (from c in companyData
                           join e in esmData on c.CompanyId equals e.CompanyId into table1
                           from e in table1
                           select new CompanyMasterCreateVM
                           {
                               CompanyId = c.CompanyId,
                               CompanyName = c.CompanyName
                           }).ToList().GroupBy(t => t.CompanyId).Select(grp => grp.First());

            var vcncydt = (from v in vacancyData
                           join e in esmData on v.VacancyId equals e.VacancyId into table1
                           from e in table1
                           select new VacancyDetailsCrtVM
                           {
                               VacancyId = v.VacancyId,
                               PostName = v.PostName,
                               CompanyId = v.CompanyId
                           }).ToList().GroupBy(t => t.VacancyId).Select(grp => grp.First());

            unitOfWork.Complete();

            List<SelectListItem> companies = esmData
                .OrderBy(n => n.CompanyId)
                .GroupBy(x => x.CompanyId).Select(x => x.First())
                    .Select(n =>
                    new SelectListItem
                    {
                        Value = n.CompanyId.ToString(),
                        Text = n.Companys.CompanyName
                    }).ToList();
            ViewBag.Companies = cmpnydt;
            ViewBag.Vacancies = vcncydt;
            ViewBag.Esmdatas = esmData;
        }

        public ActionResult Index1()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var esmData = unitOfWork.ESMDetails.GetAll();
                //var companyData = unitOfWork.CompanyMasters.Find(x=>x.CompanyId==Contains();
                var MonthSponserOffrsRecord = from e in esmData
                                              select new MonthlySponsershipOffrsRptVm
                                              {
                                                  //Companys = c,
                                                  EsmOffrsDtls = e
                                              };
                unitOfWork.Complete();
                return View(MonthSponserOffrsRecord);
            }
        }

        [HttpPost]
        public ActionResult Index(DateTime fromDate, DateTime toDate)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sponsrdata = unitOfWork.SponsorDatas.GetAll().Where(s => s.SponsorShipDate.Date >= fromDate && s.SponsorShipDate.Date <= toDate);

                var esmData = unitOfWork.ESMDetails.GetAll();
                var companyData = unitOfWork.CompanyMasters.GetAll();
                //GetMonthlyPMOData(unitOfWork, sponsrdata, esmData, companyData);
                return View();
            }
        }
    }
}