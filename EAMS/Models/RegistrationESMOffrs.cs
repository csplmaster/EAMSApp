using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.View_Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMS.Models
{
    public class RegistrationESMOffrs
    {
        [Key]
        public long RegistrationId { get; set; }
        public string ServiceType { get; set; }
        public string ServiceNo { get; set; }
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }        
        public string AdditionalQualification { get; set; }
        public string MedCategory { get; set; }
        public string PANNo { get; set; }
        public long HomeStateId { get; set; }
        [ForeignKey("HomeStateId ")]
        public virtual StateMaster HomeStates { get; set; }
        public DateTime DOC { get; set; }
        public DateTime DOR { get; set; }
        public string RetirementOrderNo { get; set; }
        public long AAdharNo { get; set; }
        public string CAddress { get; set; }
        public long CStateId { get; set; }
        [ForeignKey("CStateId ")]
        public virtual StateMaster CStates { get; set; }
        public long CCityId { get; set; }
        [ForeignKey("CCityId ")]
        public virtual CityMaster CCitys { get; set; }
        public long CPin { get; set; }
        public string PAddress { get; set; }
        public long PStateId { get; set; }
        [ForeignKey("PStateId ")]
        public virtual StateMaster PStates { get; set; }
        public long PCityId { get; set; }
        [ForeignKey("PCityId ")]
        public virtual CityMaster PCitys { get; set; }
        public long PPin { get; set; }
        public long LanlineNo { get; set; }
        public long MobileNo { get; set; }
        public string Email { get; set; }
        public long RankId { get; set; }
        public virtual RankMaster Ranks { get; set; }
        public long QualificationId { get; set; }
        public virtual QualificationMaster Qualifications { get; set; }
    }
}