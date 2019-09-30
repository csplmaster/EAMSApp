using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class OutcomeData
    {
        public OutcomeData()
        {
            iESMOffrDetails = new List<ESMOfficersDetail>();
            iESMJcoDetails = new List<ESMJcoORsDetail>();
        }
        [Key]
        public long OutcomeId { get; set; }
        public string IsSelected { get; set; }
        public string InterviewAttend { get; set; }
        public DateTime JoinDate { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancys { get; set; }
        public long EsmId { get; set; }
        public virtual ESMOfficersDetail Officers { get; set; }
        public virtual ICollection<ESMOfficersDetail> iESMOffrDetails { get; set; }
        public virtual ICollection<ESMJcoORsDetail> iESMJcoDetails { get; set; }
    }
}