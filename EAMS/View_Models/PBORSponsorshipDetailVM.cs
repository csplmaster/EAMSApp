using EAMS.Models;
using EAMS.View_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace EAMS.View_Models
{
    public class PBORSponsorshipDetailVM
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
    public class PBORsponserDetailsIndxVM : PBORSponsorshipDetailVM
    {

    }
    public class PBORsponserDetailsCrtVM : PBORSponsorshipDetailVM
    {

    }
    public class PBORsponserDetailsUpVM : PBORSponsorshipDetailVM
    {

    }
    public class PBORsponserDetailsDelVM
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Employer Id")]
        [Display(Name = "Sponsership Id")]
        public long SponsorshipId { get; set; }        
    }
}