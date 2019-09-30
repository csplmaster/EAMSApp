using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.View_Models;

namespace EAMS.Models
{
    public class ESMOfficersDetail
    {
        public ESMOfficersDetail()
        {
            iSponsorDatas = new List<SponsorData>();
        }
        [Key]
        public long EsmId { get; set; }
        public string ServiceNo { get; set; }
        public string Name { get; set; }
        public string DgrRegistrationNo { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime CommisionDate { get; set; }
        public DateTime RetirementDate { get; set; }        
        public string Address { get; set; }
        public long ContactNo { get; set; }
        public string EmailId { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        public long SbId { get; set; }
        public virtual SainikBoardDetails sainiks { get; set; }
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancys { get; set; }
        public long RankId { get; set; }
        public virtual RankMaster Ranks { get; set; }
        public long QualificationId { get; set; }
        public virtual QualificationMaster Qualifications { get; set; }
        public virtual ICollection<SponsorData> iSponsorDatas { get; set; }
    }    
}