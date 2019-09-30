using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class CorpMasterVM
    {
        [Key]
        public long CorpId { get; set; }
        [Required(ErrorMessage = "Please Enter Corps Name")]
        [Display(Name = "Corps Name")]
        public string CorpName { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}