using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class StateMaster
    {
        [Key]
        public long StateId { get; set; }
        public string StateName { get; set; }
        public string ShortName { get; set; }
    }
}