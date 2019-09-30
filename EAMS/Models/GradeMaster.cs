using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class GradeMaster
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Remarks { get; set; }
    }
}