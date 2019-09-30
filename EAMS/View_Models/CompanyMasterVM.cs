using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class CompanyMasterIndexVM
    {
        [Key]
        public long CompanyId { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Company Type")]
        public string CompanyType { get; set; }
    }
    public class CompanyMasterCreateVM
    {
        [Key]
        public long CompanyId { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Company Type")]
        public string CompanyType { get; set; }
    }
    public class CompanyMasterUpdateVM
    {
        [Key]
        [Required]
        public long CompanyId { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Company Type")]
        public string CompanyType { get; set; }
    }
    public class CompanyMasterDeleteVM
    {
        [Key]
        [Required]
        public long CompanyId { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }
    //public enum CompanyType
    //{
    //    Pvt,
    //    Govt
    //}
}