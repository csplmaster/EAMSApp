using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public sealed class DemoData
    {
        public long SponsorId { get; set; }
        public string PanelNo { get; set; }
        public long NoOfVacancy { get; set; }
        public long NoOfEAMSSponsor { get; set; }
        [DataType(DataType.Date)]
        public DateTime SponsorShipDate { get; set; }
        public string Feedback { get; set; }
        public string IsNACIssued { get; set; }
        public string Remarks { get; set; }
        //public long CompanyId { get; set; }
        //public virtual CompanyMaster Companys { get; set; }
        //public long VacancyId { get; set; }
        //public virtual VacancyMaster Vacancys { get; set; }
    }
    public class SponsorDataVM
    {
        [Key]
        public long SponsorId { get; set; }
        [Display(Name = "Category")]
        public string PersonType { get; set; }
        [Display(Name = "Panel No")]
        public string PanelNo { get; set; }
        [Display(Name = "No of Vacancy")]
        public long NoofVacancy { get; set; }
        [Display(Name = "No of Sponsor")]
        public long NoofEAMSSponsor { get; set; }
        
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Sponsorship Date")]
        [DataType(DataType.Date)]
        public DateTime SponsorShipDate { get; set; }
        [Display(Name = "Feedback")]
        public string Feedback { get; set; }
        [Display(Name = "NAC Issued")]
        public string IsNACIssued { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        //public long EsmID { get; set; }
        [Display(Name = "Company")]
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        [Display(Name = "Vacancy")]
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancys { get; set; }

    }
    
    public class SponsorDataIndexVM : SponsorDataVM
    {
        public SponsorDataIndexVM()
        {
            iESMOffrDetails = new List<ESMOfficersDetail>();
            iESMJcoDetails = new List<ESMJcoORsDetail>();
        }
        public virtual ICollection<ESMOfficersDetail> iESMOffrDetails { get; set; }
        public virtual ICollection<ESMJcoORsDetail> iESMJcoDetails { get; set; }
    }
    public class SponsorDataCreateVM : SponsorDataVM
    {
        public SponsorDataCreateVM()
        {
            iESMOffrDetails = new List<ESMOfficersDetail>();
            iESMJcoDetails = new List<ESMJcoORsDetail>();
        }
        public virtual ICollection<ESMOfficersDetail> iESMOffrDetails { get; set; }
        public virtual ICollection<ESMJcoORsDetail> iESMJcoDetails { get; set; }
    }
    public class SponsorDataUpdateVM : SponsorDataVM
    {

    }
    public class ViewModel
    {
        public IEnumerable<ESMOfficersDetail> Officers { get; set; }
        public IEnumerable<ESMJcoORsDetail> Jco { get; set; }
    }
    //public class SponsorPerDataVM
    //{
    //    public long EsmID { get; set; }
    //    public string ServiceNo { get; set; }
    //    public string Name { get; set; }
    //    public long RankId { get; set; }
    //    public virtual RankMaster Ranks { get; set; }
    //}
}