using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    public class StateMasterVM
    {
        [Key]
        [Required(ErrorMessage = "Please Enter State Id")]
        [Display(Name = "State Id")]
        public long StateId { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        [Display(Name = "State Name")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please Enter Short Name for the State")]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }
    }
    public class StateMasterCreateVM
    {
        [Key]
        [Required(ErrorMessage = "Please Enter State Id")]
        [Display(Name = "State Id")]
        public long StateId { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        [Display(Name = "State Name")]
        public string StateName { get; set; }
    }

}