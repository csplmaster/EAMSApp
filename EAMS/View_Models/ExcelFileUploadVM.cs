using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class ExcelFileUploadVM
    {
    }
    public class ESMJcoExcelUploadVM
    {
        [Required(ErrorMessage = "Please Select Service")]
        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }

        [Required(ErrorMessage = "Please Select Company")]
        [Display(Name = "Company")]
        public long CompanyId { get; set; }

        [Required(ErrorMessage = "Please Select Vacancy Id")]
        [Display(Name = "Vacancy Id")]
        public long VacancyId { get; set; }

        //[Required(ErrorMessage = "Please Enter Post Name")]
        //[Display(Name = "Post Name")]
        //public string PostName { get; set; }

        [Required(ErrorMessage = "Please Select Sainik Board Type")]
        [Display(Name = "Sainik Board Id")]
        public long SbId { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }
    }
}