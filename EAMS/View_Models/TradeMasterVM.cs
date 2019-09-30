using EAMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace EAMS.View_Models
{
    public class TradeMasterVM
    {
        [Key]
        public long TradeId { get; set; }
        [Required(ErrorMessage = "Please Enter Trade Name")]
        [Display(Name = "Trade Name")]
        public string TradeName { get; set; }
        [Required(ErrorMessage = "Please Select Service")]
        [Display(Name = "Service Group")]
        public string Service { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        [Display(Name = "Category")]
        public string Cat { get; set; }
        [Required(ErrorMessage = "Please Enter Trade Group")]
        [Display(Name = "Trade Group")]
        public string TradeGP { get; set; }
    }
}