using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class CompanyMaster
    {
        [Key]
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
    }
}