using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EAMS.Models
{
    public class RankMaster
    {
        [Key]
        public long RankId { get; set; }
        public string RankName { get; set; }
        public string Service { get; set; }
        public string RankType { get; set; }
        public string ID { get; set; }
        public Nullable<decimal> Seniority { get; set; }
        public string OffrType { get; set; }
    }
}