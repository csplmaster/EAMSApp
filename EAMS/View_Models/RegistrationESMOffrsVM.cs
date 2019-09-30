using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.View_Models;
using EAMS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMS.View_Models
{
    public class RegistrationESMOffrsVM
    {
        [Key]
        public long RegistrationId { get; set; }
        [Required(ErrorMessage = "Please Choose Service Type")]
        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }
        [Required(ErrorMessage = "Please Enter Service No")]
        [Display(Name = "Service No")]
        public string ServiceNo { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Father Name")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Religion")]
        public string Religion { get; set; }
        [Display(Name = "Additional Qualification")]
        public string AdditionalQualification { get; set; }
        [Display(Name = "Medical Category")]
        public string MedCategory { get; set; }
        [Display(Name = "Pan No")]
        public string PANNo { get; set; }
        [Display(Name = "Home State")]
        public long HomeStateId { get; set; }
        //[ForeignKey("HomeStateId ")]
        public virtual StateMaster HomeStates { get; set; }
        [Display(Name = "Date of Commision")]
        [DataType(DataType.Date)]
        public DateTime DOC { get; set; }
        [Display(Name = "Date of Retirement")]
        [DataType(DataType.Date)]
        public DateTime DOR { get; set; }
        [Display(Name = "Retirement Order No")]
        public string RetirementOrderNo { get; set; }
        [Display(Name = "Aadhar No")]
        public long AAdharNo { get; set; }
        [Display(Name = "Address")]
        public string CAddress { get; set; }
        [Display(Name = "Sate")]
        public long CStateId { get; set; }
        //[ForeignKey("CStateId ")]
        public virtual StateMaster CStates { get; set; }
        [Display(Name = "City")]
        public long CCityId { get; set; }
        //[ForeignKey("CCityId ")]
        public virtual CityMaster CCitys { get; set; }
        [Display(Name = "Pin No")]
        //[DataType(DataType.PostalCode)]
        public long CPin { get; set; }
        [Display(Name = "Address")]
        public string PAddress { get; set; }
        [Display(Name = "State")]
        public long PStateId { get; set; }
        //[ForeignKey("PStateId ")]
        public virtual StateMaster PStates { get; set; }
        [Display(Name = "City")]
        public long PCityId { get; set; }
       // [ForeignKey("PCityId ")]
        public virtual CityMaster PCitys { get; set; }
        [Display(Name = "Pin No")]
        public long PPin { get; set; }
        [Display(Name = "Telephone No")]
        public long LanlineNo { get; set; }
        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        public long MobileNo { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name ="Rank")]
        public long RankId { get; set; }
        public virtual RankMaster Ranks { get; set; }
        [Display(Name = "Qualification")]
        public long QualificationId { get; set; }
        public virtual QualificationMaster Qualifications { get; set; }
    }
    public class RegsESMOffrsIndexVM : RegistrationESMOffrsVM
    {

    }
    public class RegsESMOffrsCreateVM : RegistrationESMOffrsVM
    {

    }
    public class RegsESMOffrsUpdateVM : RegistrationESMOffrsVM
    {

    }
}