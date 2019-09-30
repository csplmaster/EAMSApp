using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMS.Models
{
    public class VacancyMaster
    {
        public VacancyMaster()
        {
            iQualificationDesirables = new List<QualificationMaster>();
            iQualificationEssentials = new List<QualificationMaster>();
        }
        [Key]
        public long VacancyId { get; set; }
        public string VacancyCode { get; set; }
        public string PostName { get; set; }
        public string JobFunction { get; set; }
        public int Vacancies { get; set; }

        [Column("VacancyType")]
        public string VacancyTypeString { get; set; }
        public string LevelPost { get; set; }
        //public string EssentQualification { get; set; }
        //public string DesireQualificaton { get; set; }

        public int? WorkExperience { get; set; }
        public int? AgeMin { get; set; }
        public int AgeMax { get; set; }
        public string JobLocation { get; set; }
        public double SalaryMin { get; set; }
        public double SalaryMax { get; set; }
        public string AdditionalBenefits { get; set; }
        public DateTime LastDate { get; set; }

        public int? ModeOfApplicationId { get; set; }
        //[NotMapped]
        //public ModeOfApplication ModeOfApplication { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }
        public long StateId { get; set; }
        public virtual StateMaster States { get; set; }
        public long CityId { get; set; }
        public virtual CityMaster Citys { get; set; }
        public int GradeId { get; set; }
        public virtual GradeMaster Grades { get; set; }

        public virtual ICollection<QualificationMaster> iQualificationDesirables { get; set; }
        public virtual ICollection<QualificationMaster> iQualificationEssentials { get; set; }


    }
    public enum vacancyType
    {
        Contractual,
        Permanent
    }
    public enum ModeOfApplication
    {
        None = 0,
        [Display(Name = "Forward to DGR")]
        Forward_to_DGR = 1,
        [Display(Name = "Directly Applied to User Org")]
        Directly_Applied = 2,
        [Display(Name = "Applied Online")]
        Applied_Online = 3,
        [Display(Name = "Fwd Names through RSB/ZSB to DGR")]
        Through_RSB_ZSB = 4
    }
}