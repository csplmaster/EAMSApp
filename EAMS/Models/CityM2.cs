using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class CityM2
    {
        [Key]
        public long CityId { get; set; }
        public string CityName { get; set; }
        public string CodeName { get; set; }
        public long StateId { get; set; }
        public virtual StateMaster States { get; set; }
    }
}