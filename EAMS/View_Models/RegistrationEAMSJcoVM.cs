using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EAMS.View_Models;
using EAMS.Models;

namespace EAMS.View_Models
{
    public class RegistrationEAMSJcoVM
    {
        [Key]
        public long RegistrationID { get; set; }
        public string ServiceType { get; set; }
        public string ServiceNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string AdditionalQualification { get; set; }
        public string MedCategory { get; set; }
        public string PANNo { get; set; }
        public long AadharNo { get; set; }
        public long HomeStateId { get; set; }
        [ForeignKey("HomeStateId ")]
        public virtual StateMaster HomeStates { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOR { get; set; }
        public string RetirementOrderNo { get; set; }
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
        public long LandlineNo { get; set; }
        public long MobileNo { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string RecordOffice { get; set; }
        public string ROfilesPath { get; set; }
        public long CorpId { get; set; }
        public virtual CorpMaster Corps { get; set; }
        public long TradeId { get; set; }
        public virtual TradeMaster Trades { get; set; }
        public long RankId { get; set; }
        public virtual RankMaster Ranks { get; set; }
        public long QualificationId { get; set; }
        public virtual QualificationMaster Qualifications { get; set; }
    }

    public class RegEAMSJcoIndex : RegistrationEAMSJcoVM
    {

    }
    public class RegEAMSJcoCreate : RegistrationEAMSJcoVM
    {

    }
    public class RegEAMSJcoUpdate : RegistrationEAMSJcoVM
    {

    }
}