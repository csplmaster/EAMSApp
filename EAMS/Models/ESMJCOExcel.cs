using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExcelDataReader;
namespace EAMS.Models
{
    public class ESMJCOExcel
    {
        public long EsmId { get; set; }
        public long CompanyId { get; set; }
        public string PostName { get; set; }
        public string ServiceNo { get; set; }
        public long RankId { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Corps { get; set; }
        public string Trade { get; set; }
        public string category { get; set; }
        public long QualificationId { get; set; }
        public string WorkExp { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }
        public string EmailId { get; set; }
    }
}