using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class CityMasterVM
    {
        [Key]
        [Required(ErrorMessage = "Please Enter City Id")]
        [Display(Name = "City Id")]
        public long CityId { get; set; }

        [Required(ErrorMessage = "Please Enter State Id")]
        [Display(Name = "State Id")]
        public long StateId { get; set; }
        //[ForeignKey("StateId")]
        [Required(ErrorMessage = "Please Enter City Name")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Please Enter Short Name for the City")]
        [Display(Name = "Short Name")]
        public string CodeName { get; set; }
        public virtual StateMaster States { get; set; }
    }
}