using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.View_Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMS.Models
{
    public class CorpMaster
    {
        [Key]
        public long CorpId { get; set; }
        public string CorpName { get; set; }
        public string Description { get; set; }
    }
}