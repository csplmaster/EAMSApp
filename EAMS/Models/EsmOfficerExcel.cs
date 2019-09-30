using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExcelDataReader;
namespace EAMS.Models
{
    public class EsmOfficerExcel
    {
        public long EsmId { get; set; }
        public long CompanyId { get; set; }
        public string PostName { get; set; }
        public string ServiceNo { get; set; }
        public long RankId { get; set; }
        public string Name { get; set; }
        public string DgrRegistrationNo { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime CommisionDate { get; set; }
        public DateTime RetirementDate { get; set; }
        public long QualificationId { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }
        public string EmailId { get; set; }
    }
}