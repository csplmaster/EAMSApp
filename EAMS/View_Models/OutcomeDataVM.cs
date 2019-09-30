using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class OutcomeDataVM
    {
        [Key]
        public long OutcomeId { get; set; }
        public string IsSelected { get; set; }
        public string InterviewAttend { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancys { get; set; }
        public long EsmId { get; set; }
        public virtual ESMOfficersDetail Officers { get; set; }
        
    }
    public class OutcomeDataIndexVM : OutcomeDataVM
    {

    }
    public class OutcomeDataCreateVM : OutcomeDataVM
    {

    }
    public class OutcomeDataUpdateVM : OutcomeDataVM
    {

    }
}