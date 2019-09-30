using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class NotingMaster
    {
       [Key]
       public long NotingId { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Company { get; set; }
        public long VacancyId { get; set; }
        public virtual VacancyMaster Vacancies { get; set; }
        public string LetterNo { get; set; }
        public DateTime LetterDate { get; set; }
        public string Remarks { get; set; }        
    }
}