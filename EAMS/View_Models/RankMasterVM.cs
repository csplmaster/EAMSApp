using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EAMS.View_Models
{
    public class RankMasterVM
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Rank Id")]
        [Display(Name = "Rank Id")]
        public long RankId { get; set; }

        [Required(ErrorMessage = "Please Enter Rank")]
        [Display(Name = "Rank")]
        public string RankName { get; set; }
    }
    public class RankMasterIndxVM : RankMasterVM
    {
        
    }
    //public class RankMasterCreateVM: RankMasterVM
    //{
        
    //}
}