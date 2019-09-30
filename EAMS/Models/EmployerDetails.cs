using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class EmployerDetails
    {
        [Key]
        public long EmployerId { get; set; }
        public string Branch { get; set; }
        public string BranchCode { get; set; }
        public string PersonName { get; set; }
        public string PersonDesignation { get; set; }
        public string PersonContact { get; set; }
        public string PersonEmailId { get; set; }
        public int PinCode { get; set; }
        public string FullAddress { get; set; }
        public string EmailId { get; set; }
        public long FaxNo { get; set; } 
        public long ContactNo { get; set; }
        public long PhoneNo { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        //[ForeignKey("StateId")]
        public long StateId { get; set; }
        //[ForeignKey("StateId")]
        public virtual StateMaster States { get; set; }
        public long CityId { get; set; }
        public virtual CityMaster Citys { get; set; }
    }
}
