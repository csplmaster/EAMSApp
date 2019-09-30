using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.Models;

namespace EAMS.Models
{
    public class ESMJcoORsDetail
    {
        public ESMJcoORsDetail()
        {
            iSponsorDatas = new List<SponsorData>();
        }
        [Key]
        public long EsmId { get; set; }
        public string ServiceNo { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Corps { get; set; }
        public string Trade { get; set; }
        public string Category { get; set; }
        public string WorkExp { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }
        public string EmailId { get; set; }
        public string DgrRegistrationNo { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancys { get; set; }
        public long SbId { get; set; }
        public virtual SainikBoardDetails sainiks { get; set; }
        public long RankId { get; set; }
        public virtual RankMaster Ranks { get; set; }
        public long QualificationId { get; set; }
        public virtual QualificationMaster Qualifications { get; set; }
        public virtual ICollection<SponsorData> iSponsorDatas { get; set; }
    }
}