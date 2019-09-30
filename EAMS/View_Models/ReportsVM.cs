using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class ReportsVM
    {
    }
    public class MonthlySponsershipOffrsRptVm
    {
        public ESMOfficersDetail EsmOffrsDtls { get; set; }
        public CompanyMaster Companys { get; set; }
        public VacancyMaster Vacancys { get; set; }
    }
    public class JobOpporOffcrRptVM
    {
        //public VacancyMaster Vacancys { get; set; }
        [Key]
        public long VacancyId { get; set; }

        [Display(Name = "Vacancy Code")]
        public string VacancyCode { get; set; }

        [Display(Name = "Post Name")]
        public string PostName { get; set; }


        [Display(Name = "No of Vacancy")]
        public int Vacancies { get; set; }

        [Display(Name = "Last Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime LastDate { get; set; }

        [Display(Name = "Mode of Application")]
        public int? ModeOfApplicationId
        {
            get { return (int?)ModeOfApplication; }
            private set { ModeOfApplication = (ModeOfApplication)Enum.Parse(typeof(ModeOfApplication), Convert.ToString(value == null ? 0 : value), true); }
        }
        public ModeOfApplication ModeOfApplication { get; set; }

        [Display(Name = "Company Id")]
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }

    }

}