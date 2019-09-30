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
    public class MonthlyPMOPBORController : Controller
    {
        // GET: MonthlyPMOPBOR
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sponsrdata = unitOfWork.SponsorDatas.GetAll();
                var esmData = unitOfWork.ESMJcoDetails.GetAll();
                var companyData = unitOfWork.CompanyMasters.GetAll();
                GetMonthlyPMOData(unitOfWork, sponsrdata, esmData, companyData);
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(DateTime fromDate, DateTime toDate)
        {
            ViewBag.Fdate = Convert.ToDateTime(fromDate).ToString("dd MMM yyyy");
            ViewBag.Tdate = Convert.ToDateTime(toDate).ToString("dd MMM yyyy"); ;
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {

                var sponsrdata = unitOfWork.SponsorDatas.GetAll().Where(s => s.SponsorShipDate.Date >= fromDate && s.SponsorShipDate.Date <= toDate);
                var esmData = unitOfWork.ESMJcoDetails.GetAll();
                var companyData = unitOfWork.CompanyMasters.GetAll();
                GetMonthlyPMOData(unitOfWork, sponsrdata, esmData, companyData);
                return View();
            }
        }
        private void GetMonthlyPMOData(UnitWork1 unitOfWork, IEnumerable<SponsorData> sponsrdata, IEnumerable<ESMJcoORsDetail> esmData, IEnumerable<CompanyMaster> companyData)
        {
            var MonthPmoRecord = from s in sponsrdata
                                     //where (s.SponsorShipDate.Date >= Convert.ToDateTime("20 sep 2018") && s.SponsorShipDate.Date <= DateTime.Now.Date)
                                 from es in s.iESMJcoDetails
                                 join e in esmData on es.EsmId equals e.EsmId into table1
                                 from e in table1.ToList()
                                 join c in companyData on e.CompanyId equals c.CompanyId into table2
                                 from c in table2.ToList()
                                     //join 
                                 select new MonthlyPMOJcoVM
                                 {
                                     Sponsors = s,
                                     EsmJcoOr = e,
                                     Companys = c
                                 };
            unitOfWork.Complete();
            int TtlEsmSponsoredGovt = MonthPmoRecord.Where(x => x.Companys.CompanyType == "Govt").ToList().Count;
            int TtlEsmSponsoredPvt = MonthPmoRecord.Where(x => x.Companys.CompanyType == "Pvt").ToList().Count;

            var MonPmoDt = new MothlyJCOPMODataVM()
            {
                EsmSponsoredGovt = TtlEsmSponsoredGovt,
                EsmSponsoredPvt = TtlEsmSponsoredPvt,
            };
            ViewBag.MonPmoData = MonPmoDt;
        }
    }
}