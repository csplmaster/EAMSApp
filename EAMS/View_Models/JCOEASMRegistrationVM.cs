using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.View_Models;
using EAMS.Models;

namespace EAMS.View_Models
{
    public class JCOEASMRegistrationVM
    {
        [Key]
        public long RegistrationID { get; set; }

        [Required(ErrorMessage ="Please Select One of these from Service Type")]
        [Display(Name ="Service")]
        public string ServiceType { get; set; }

        [Required(ErrorMessage = "Please Enter Service No")]
        [Display(Name = "Service No")]
        public string ServiceNo { get; set; }

        [Required(ErrorMessage = "Please Select One of these from Rank")]
        [Display(Name = "Rank")]
        public long RankID { get; set; }

        public virtual RankMaster Ranks { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Father's Name")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Selet Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Religio Name")]
        [Display(Name = "Religion")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Please Qualification")]
        [Display(Name = "Qualification")]
        public long QualificationId { get; set; }

        public virtual QualificationMaster Qualifications { get; set; }

        [Display(Name ="Additional Qualification")]
        public string AddlQualification { get; set; }

        [Required(ErrorMessage = "Please Select Medical Category")]
        [Display(Name = "Medical Category")]
        public string MedCategory { get; set; }

        [Required(ErrorMessage = "Please Enter Pan No")]
        [Display(Name = "Pan No")]
        public string PANNo { get; set; }
        [Display(Name ="Aadhar No")]
        public long AAdharNo { get; set; }

        [Required(ErrorMessage = "Please Select Home State")]
        [Display(Name = "Home State")]
        public long HomeState { get; set; }
        public virtual StateMaster States { get; set; }

        [Required(ErrorMessage = "Please Enter Date of Retirement")]
        [Display(Name = "Date of Retirement")]
        public DateTime DOR { get; set; }

        [Required(ErrorMessage = "Please Enter Retirement Order")]
        [Display(Name = "Retirement Order")]
        public string RetirementOrderNo { get; set; }

        [Required(ErrorMessage = "Please Enter Correspondance Address")]
        [Display(Name = "Correspondance Address")]
        public string CAddress { get; set; }

        [Required(ErrorMessage = "Please Select Correspondance Address State")]
        [Display(Name = "Correspondance State")]
        public long CState { get; set; }
        public virtual StateMaster CStates { get; set; }

        [Required(ErrorMessage = "Please Select Correspondance City")]
        [Display(Name = "Correspondance City")]
        public string CCity { get; set; }

        [Required(ErrorMessage = "Please Enter Correspondance Pin")]
        [Display(Name = "Correspondance Pin No")]
        public long CPin { get; set; }

        [Required(ErrorMessage = "Please Enter Permanent Address")]
        [Display(Name = "Permanent Address")]
        public string PAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Permanent Address State")]
        [Display(Name = "Permanent State")]
        public string PState { get; set; }
        public virtual StateMaster PSatets { get; set; }
        [Required(ErrorMessage = "Please Enter Permanent Address City")]
        [Display(Name = "Permanent City")]
        public string PCity { get; set; }

        [Required(ErrorMessage = "Please Enter Permanent Address Pin no")]
        [Display(Name = "Pin No")]
        public long PPin { get; set; }

        [Display(Name ="LandLine No")]
        public long LandlineNo { get; set; }

        [Required(ErrorMessage = "Please Enter Contact No")]
        [Display(Name = "Mobile")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name ="Record Office")]
        public string RecordOffice { get; set; }

        [Required(ErrorMessage = "Please Browse Retirement Order File for Upload")]
        [Display(Name = "Retirement Order File")]
        public string ROfilesPath { get; set; }
        public HttpPostedFileBase ROfiles { get; set; }
    }
    public class JCOEAMSRegtIndexVM
    {
        [Key]
        public long RegistrationID { get; set; }

        [Required(ErrorMessage = "Please Select One of these from Service Type")]
        [Display(Name = "Service")]
        public string ServiceType { get; set; }

        [Required(ErrorMessage = "Please Enter Service No")]
        [Display(Name = "Service No")]
        public string ServiceNo { get; set; }

        [Required(ErrorMessage = "Please Select One of these from Rank")]
        [Display(Name = "Rank")]
        public long RankID { get; set; }

        public virtual RankMaster Ranks { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Father's Name")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Selet Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Religio Name")]
        [Display(Name = "Religion")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Please Qualification")]
        [Display(Name = "Qualification")]
        public long QualificationId { get; set; }

        public virtual QualificationMaster Qualifications { get; set; }

        [Display(Name = "Additional Qualification")]
        public string AddlQualification { get; set; }

        [Required(ErrorMessage = "Please Select Medical Category")]
        [Display(Name = "Medical Category")]
        public string MedCategory { get; set; }

        [Required(ErrorMessage = "Please Enter Pan No")]
        [Display(Name = "Pan No")]
        public string PANNo { get; set; }
        [Display(Name = "Aadhar No")]
        public long AAdharNo { get; set; }

        [Required(ErrorMessage = "Please Select Home State")]
        [Display(Name = "Home State")]
        public long HomeState { get; set; }
        public virtual StateMaster States { get; set; }

        [Required(ErrorMessage = "Please Enter Date of Retirement")]
        [Display(Name = "Date of Retirement")]
        public DateTime DOR { get; set; }

        [Required(ErrorMessage = "Please Enter Retirement Order")]
        [Display(Name = "Retirement Order")]
        public string RetirementOrderNo { get; set; }

        [Required(ErrorMessage = "Please Enter Correspondance Address")]
        [Display(Name = "Correspondance Address")]
        public string CAddress { get; set; }

        [Required(ErrorMessage = "Please Select Correspondance Address State")]
        [Display(Name = "Correspondance State")]
        public long CState { get; set; }
        public virtual StateMaster CStates { get; set; }

        [Required(ErrorMessage = "Please Select Correspondance City")]
        [Display(Name = "Correspondance City")]
        public string CCity { get; set; }

        [Required(ErrorMessage = "Please Enter Correspondance Pin")]
        [Display(Name = "Correspondance Pin No")]
        public long CPin { get; set; }

        [Required(ErrorMessage = "Please Enter Permanent Address")]
        [Display(Name = "Permanent Address")]
        public string PAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Permanent Address State")]
        [Display(Name = "Permanent State")]
        public string PState { get; set; }
        public virtual StateMaster PSatets { get; set; }
        [Required(ErrorMessage = "Please Enter Permanent Address City")]
        [Display(Name = "Permanent City")]
        public string PCity { get; set; }

        [Required(ErrorMessage = "Please Enter Permanent Address Pin no")]
        [Display(Name = "Pin No")]
        public long PPin { get; set; }

        [Display(Name = "LandLine No")]
        public long LandlineNo { get; set; }

        [Required(ErrorMessage = "Please Enter Contact No")]
        [Display(Name = "Mobile")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Record Office")]
        public string RecordOffice { get; set; }

        [Required(ErrorMessage = "Please Browse Retirement Order File for Upload")]
        [Display(Name = "Retirement Order File")]
        public string ROfilesPath { get; set; }
    }
    public class JCOEAMSRegtCreateVM : JCOEASMRegistrationVM
    {

    }
    public class JCOEAMSRegtUpdateVM : JCOEASMRegistrationVM
    {

    }
}