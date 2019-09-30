using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class MothlyPMOVM
    {
        public SponsorData Sponsors { get; set; }
        public ESMOfficersDetail EsmOffrsDtls { get; set; }
        public CompanyMaster Companys { get; set; }
    }
    public class MothlyPMODataVM
    {
        public int EsmSponsoredGovt { get; set; }
        public int EsmSponsoredPvt { get; set; }
        public int EsmSponsored { get { return EsmSponsoredGovt + EsmSponsoredPvt; } }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime StartDate { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime EndDate { get; set; }
    } 

    public class Weekspons
    {
        public int NoOfVacancy { get; set; }
        public int NoOfEAMSSponsor { get; set; }
    }
    
}