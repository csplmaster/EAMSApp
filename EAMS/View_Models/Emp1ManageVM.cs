using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EAMS.View_Models
{
    [NotMapped]
    public class Emp1Create_VM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Age")]
        public string Age { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
    [NotMapped]
    public class Emp1Update_VM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Age")]
        public string Age { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
    [NotMapped]
    public class Emp1Delete_VM
    {
        public int Id { get; set; }
    }
}