using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class SainikBoardDetails
    {
        [Key]
        public long SbId { get; set; }
        public string SbType { get; set; }
        public string Sbname { get; set; }
        public string Description { get; set; }
        public string PersonName { get; set; }
        public long MobileNo { get; set; }
        public string Email { get; set; }

    }
}