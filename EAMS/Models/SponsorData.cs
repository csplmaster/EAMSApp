using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class SponsorData
    {
        public SponsorData()
        {
            iESMOffrDetails = new List<ESMOfficersDetail>();
            iESMJcoDetails = new List<ESMJcoORsDetail>();
        }
        [Key]
        public long SponsorId { get; set; }
        public string PanelNo { get; set; }
        public long NoOfVacancy { get; set; }
        public long NoOfEAMSSponsor { get; set; }
        public DateTime SponsorShipDate { get; set; }
        public string Feedback { get; set; }
        public string IsNACIssued { get; set; }
        public string Remarks { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancys { get; set; }
        //public long EsmId { get; set; }
        //public virtual ESMOfficersDetail ESMOfficersDetail { get; set; }
        public string PersonType { get; set; }
        public virtual ICollection<ESMOfficersDetail> iESMOffrDetails { get; set; }
        public virtual ICollection<ESMJcoORsDetail> iESMJcoDetails { get; set; }
    }
}