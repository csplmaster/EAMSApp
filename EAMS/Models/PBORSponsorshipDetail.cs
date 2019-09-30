using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class PBORSponsorshipDetail
    {
        [Key]
        public long SponsorshipId { get; set; }

        public string SponsEmpType { get; set; }
        public string panelNo { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companies { get; set; }
        public string ContactPersonName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Post { get; set; }
        public long TotalVacancy { get; set; }
        public long TotalESMSponsered { get; set; }
        public DateTime SponserDate { get; set; }
        public long ContactNo { get; set; }
        public string Email { get; set; }
        public string FeedBack { get; set; }
        public string NACIssued { get; set; }
        public string Remarks { get; set; }
    }
}