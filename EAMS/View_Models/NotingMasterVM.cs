using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.Models;

namespace EAMS.View_Models
{
    public class NotingMasterVM
    {
        [Key]
        public long NotingId { get; set; }
        [Required(ErrorMessage ="Please Select Organisation Name")]
        [Display(Name ="Organisation Name")]
        public long CompanyId { get; set; }
        public virtual CompanyMaster Company { get; set; }
        [Required(ErrorMessage = "Please Select Post Name")]
        [Display(Name = "Post Name")]
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancies { get; set; }
        [Required(ErrorMessage = "Please Enter Letter No")]
        [Display(Name = "Latter No")]
        public string LetterNo { get; set; }
        [Required(ErrorMessage = "Please Letter Date")]
        [Display(Name = "Letter Date")]
        public DateTime LetterDate { get; set; }
        public string Remarks { get; set; }
    }
    public class NotingIndexVM : NotingMasterVM
    {

    }
    public class NotingCreateVM : NotingMasterVM
    {

    }
    public class NotingUpVM : NotingMasterVM
    {

    }
}