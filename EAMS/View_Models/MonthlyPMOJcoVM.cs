using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class MonthlyPMOJcoVM
    {
        public SponsorData Sponsors { get; set; }
        public ESMJcoORsDetail EsmJcoOr { get; set; }
        public CompanyMaster Companys { get; set; }
    }
    public class MothlyJCOPMODataVM
    {
        public int EsmSponsoredGovt { get; set; }
        public int EsmSponsoredPvt { get; set; }
        public int EsmSponsored { get { return EsmSponsoredGovt + EsmSponsoredPvt; } }
    }

    public class SponJcocountDataVM
    {
        public string SponsMonth { get; set; }
        public int JcoSponCount { get; set; }
    }
}