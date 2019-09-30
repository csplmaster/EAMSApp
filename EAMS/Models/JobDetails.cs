using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAMS.Models
{
    public class JobDetails
    {
        [Key]
        public int JobId { get; set; }
        public string PostName { get; set; }
        public string JobFunction { get; set; }
        public int Vacancies { get; set; }
        public int WorkExperience { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public string JobLocation { get; set; }
        public double SalaryMin { get; set; }
        public double SalaryMax { get; set; }
        public string AdditionalBenefits { get; set; }
    }
    public enum JobType
    {
        Contractual,
        Permanent
    }
}