using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class GradeMasterVM
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Remarks { get; set; }
    }
}