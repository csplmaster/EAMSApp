using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public abstract class EmployerDetailsVM
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Employer Id")]
        [Display(Name = "Employer Id")]
        public long EmployerId { get; set; }
        [Required(ErrorMessage = "Please Enter Branch")]
        [Display(Name = "Branch")]
        public string Branch { get; set; }
        [Required(ErrorMessage = "Please Enter Branch Code")]
        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; }
        [Required(ErrorMessage = "Please Enter Person Name")]
        [Display(Name = "Person Name")]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "Please Enter Person Designation")]
        [Display(Name = "Person Designation")]
        public string PersonDesignation { get; set; }
        [Required(ErrorMessage = "Please Enter Person Contact")]
        [Display(Name = "Person Contact")]
        public string PersonContact { get; set; }
        [Required(ErrorMessage = "Please Enter Person Email Id")]
        [Display(Name = "Person Email Id")]
        public string PersonEmailId { get; set; }
        [Required(ErrorMessage = "Please Enter Pin Code")]
        [Display(Name = "Pin Code")]
        public int PinCode { get; set; }
        [Required(ErrorMessage = "Please Enter Full Address")]
        [Display(Name = "Full Address")]
        public string FullAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Email Id")]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please Enter Fax No")]
        [Display(Name = "Fax No")]
        public long FaxNo { get; set; }
        [Required(ErrorMessage = "Please Enter Contact No")]
        [Display(Name = "Contact No")]
        public long ContactNo { get; set; }
        [Required(ErrorMessage = "Please Enter Phone No")]
        [Display(Name = "Phone No")]
        public long PhoneNo { get; set; }

        [Required(ErrorMessage = "Please Enter Company")]
        [Display(Name = "Company Id")]
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        [Display(Name = "State Id")]
        public long StateId { get; set; }
        public virtual StateMaster States { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        [Display(Name = "City Id")]
        public long CityId { get; set; }
        public virtual CityMaster Citys { get; set; }
    }
    public class EmployerDetailsIndxVM : EmployerDetailsVM
    {
        
    }
    public class EmployerDetailsCrtVM : EmployerDetailsVM
    {
        
    }
    public class EmployerDetailsUpVM : EmployerDetailsVM
    {
        
    }
    public class EmployerDetailsDelVM
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Employer Id")]
        [Display(Name = "Employer Id")]
        public long EmployerId { get; set; }
        //public string Branch { get; set; }
        //public string BranchCode { get; set; }
        //public string PersonName { get; set; }
        //public string PersonDesignation { get; set; }
        //public string PersonContact { get; set; }
        //public string PersonEmailId { get; set; }
        //public int PinCode { get; set; }
        //public string FullAddress { get; set; }
        //public string EmailId { get; set; }
        //public long FaxNo { get; set; }
        //public long ContactNo { get; set; }
        //public long PhoneNo { get; set; }
        //public long CompanyId { get; set; }
        //public virtual CompanyMaster Companys { get; set; }
        //public long StateId { get; set; }
        //public virtual StateMaster States { get; set; }
        //public long CityId { get; set; }
        //public virtual CityMaster Citys { get; set; }
    }
}