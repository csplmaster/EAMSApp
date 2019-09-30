using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{

    public class ESMOfficersDetailVM
    {
        [Key]
        public long EsmId { get; set; }

        [Display(Name ="Service No")]
        [Required(ErrorMessage ="Please Enter Service No")]
        public string ServiceNo { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string Name { get; set; }
        [Display(Name = "DGR Registration No")]
        [Required(ErrorMessage = "Please Enter DGR Registration No")]
        public string DgrRegistrationNo { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
        [Display(Name = "Commision Date")]
        [Required(ErrorMessage = "Please Enter Date of Commision")]
        [DataType(DataType.Date)]
        public DateTime CommisionDate { get; set; }
        [Display(Name = "Retirement Date")]
        [Required(ErrorMessage = "Please Enter Date of Retirement")]
        [DataType(DataType.Date)]
        public DateTime RetirementDate { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Enter Full Address")]
        public string Address { get; set; }
        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Please Enter Phone or Mobile No")]
        [DataType(DataType.PhoneNumber)]
        public long ContactNo { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Display(Name = "Organisation Name")]
        [Required(ErrorMessage = "Please Select Company Name from Dropdown")]
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        [Display(Name = "Sainik Board")]
        [Required(ErrorMessage = "Please Select Sainik Board Name from Dropdown")]
        public long SbId { get; set; }
        public virtual SainikBoardDetails sainiks { get; set; }
        [Display(Name = "Post Name")]
        [Required(ErrorMessage = "Please Select Vacancy Name from Dropdown")]
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancys { get; set; }
        [Display(Name = "Rank")]
        [Required(ErrorMessage = "Please Select Rank from Dropdown")]
        public long RankId { get; set; }
        public virtual RankMaster Ranks { get; set; }
        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Please Select Qualification from Dropdown")]
        public long QualificationId { get; set; }
        public virtual QualificationMaster Qualifications { get; set; }
        [Required(ErrorMessage = "Please Select One of these from Service Type")]
        [Display(Name = "Service")]
        public string ServiceType { get; set; }
    }

    public class ESMDetailsIndexVM : ESMOfficersDetailVM
    {

    }
    public class ESMDetailsCrtVM : ESMOfficersDetailVM
    {

    }
    public class ESMDetailsUpVM : ESMOfficersDetailVM
    {

    }
    public class EmsVacancyData
    {
        public long EsmId { get; set; }
        public string ServiceNo { get; set; }
        public string RankName { get; set; }
        public int RankId { get; set; }
        public virtual RankMaster Ranks { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}