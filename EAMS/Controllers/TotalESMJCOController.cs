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
    public class TotalESMJCOController : Controller
    {
        public class UserData
        {
            public int Countdata { get; set; }
            public string Month { get; set; }
        }
        private EAMSContext db = new EAMSContext();
        // GET: TotalESMJCO
        
        public ActionResult Index()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Fdate = "01 Aug 2018";
                ViewBag.Tdate = "31 Aug 2018";
                var sponsrdata = unitOfWork.SponsorDatas.GetAll();
                Getdata(unitOfWork,sponsrdata);
                return View();
            }
        }
        
        public void Getdata(UnitWork1 unitOfWork, IEnumerable<SponsorData> sponsrdata)
        {
            var Spondata = from s in sponsrdata
                           .GroupBy(s=>s.SponsorShipDate.Month)
                           select new UserData
                           {
                               Countdata = s.Count(),
                               Month = s.FirstOrDefault().SponsorShipDate.Month.ToString()
                           };
            string MonthName = sponsrdata.FirstOrDefault().SponsorShipDate.Month.ToString("MMM");
            int TotalCount = sponsrdata.Count();
            foreach (var userdata in Spondata)
            {
                switch (userdata.Month)
                {
                    case "1":
                        userdata.Month = "Jan";
                        break;
                    case "2":
                        userdata.Month = "Feb";
                        break;
                    case "3":
                        userdata.Month = "Mar";
                        break;
                    case "4":
                        userdata.Month = "Apr";
                        break;
                    case "5":
                        userdata.Month = "May";
                        break;
                    case "6":
                        userdata.Month = "Jun";
                        break;
                    case "7":
                        userdata.Month = "Jul";
                        break;
                    case "8":
                        userdata.Month = "Aug";
                        break;
                    case "9":
                        userdata.Month = "Sep";
                        break;
                    case "10":
                        userdata.Month = "Oct";
                        break;
                    case "11":
                        userdata.Month = "Nov";
                        break;
                    case "12":
                        userdata.Month = "Dec";
                        break;
                    default:
                        userdata.Month = "error";
                        break;
                }
            }
            unitOfWork.Complete();
            
            var Sponcount = new SponJcocountDataVM()
            {
                SponsMonth = MonthName,
                JcoSponCount = TotalCount,
            };
            ViewBag.Sponcount = Sponcount;
        }
    }
}