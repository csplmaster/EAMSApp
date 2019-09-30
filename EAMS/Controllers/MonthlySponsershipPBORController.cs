using EAMS.DB_Contexts;
using EAMS.Models;
using EAMS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EAMS.Controllers
{
    public class MonthlySponsershipPBORController : Controller
    {
        // GET: MonthlySponsershipPBOR
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
        public ActionResult Index(DateTime fromDate)
        {
            string monthname = Convert.ToDateTime(fromDate).ToString("MMMM yyyy");
            ViewBag.SponMonth = monthname;
            DateTime fdate = Convert.ToDateTime("1 " + monthname);
            DateTime tdate = Convert.ToDateTime("30 " + monthname);
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var sponsrdata = unitOfWork.SponsorDatas.GetAll().Where(s => s.SponsorShipDate.Date >= fdate && s.SponsorShipDate.Date <= tdate);
                var esmData = unitOfWork.ESMJcoDetails.GetAll();
                var companyData = unitOfWork.CompanyMasters.GetAll();
                GetMonthlyPMOData(unitOfWork, sponsrdata, esmData, companyData);
                return View();
            }
        }

        private void GetMonthlyPMOData(UnitWork1 unitOfWork, IEnumerable<SponsorData> sponsrdata, IEnumerable<ESMJcoORsDetail> esmData, IEnumerable<CompanyMaster> companyData)
        {
            ViewBag.sdata = "ONGC";
            
        }
    }
}