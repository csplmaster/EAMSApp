using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EAMS.View_Models
{
    public class SainikBoardDetailsVM
    {
        [Key]
        [Required(ErrorMessage = "Please Select Sainik Board Type")]
        [Display(Name = "Sainik Board Id")]
        public long SbId { get; set; }

        [Required(ErrorMessage ="Please Select Sainik Board Type")]
        [Display(Name ="Sainik Board Type")]
        public string SbType { get; set; }
        [Required(ErrorMessage = "Please Enter Sainik Board Name")]
        [Display(Name = "Sainik Board Name")]
        public string SbName { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter Contact Person Name")]
        [Display(Name = "Contact Person Name")]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "Please Enter Contact Person Mobile No")]
        [Display(Name = "Mobile No")]
        public long Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address of Conatct Person.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
    public class SainikBoardIndexVM : SainikBoardDetailsVM
    {

    }
    public class SainikBoardCreateVM : SainikBoardDetailsVM
    {

    }
    public class SainikBoardUpdtVM : SainikBoardDetailsVM
    {

    }
}