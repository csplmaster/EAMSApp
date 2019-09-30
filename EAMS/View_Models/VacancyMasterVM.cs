using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMS.View_Models
{
    public class VacancyMasterVM
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Vacancy Id")]
        [Display(Name = "Vacancy Id")]
        public long VacancyId { get; set; }

        [Required(ErrorMessage = "Please Enter Vacancy Code")]
        [Display(Name = "Vacancy Code")]
        public string VacancyCode { get; set; }

        [Required(ErrorMessage = "Please Enter Post Name")]
        [Display(Name = "Post Name")]
        public string PostName { get; set; }

        [Required(ErrorMessage = "Please Enter Job function")]
        [Display(Name = "Job Function")]
        public string JobFunction { get; set; }

        [Required(ErrorMessage = "Please Enter Vacancy Type")]
        [Display(Name = "Vacancy Type")]
        public string VacancyTypeString { get; set; }
        //public string VacancyTypeString
        //{
        //    get { return VacancyType.ToString(); }
        //    private set { VacancyType = value.ParseEnum<VacancyType>(); }
        //}

        [Required(ErrorMessage = "Please Enter No of Vacancy")]
        [Display(Name = "No of Vacancy")]
        public int Vacancies { get; set; }

        [Required(ErrorMessage = "Please Enter Level/Post")]
        [Display(Name = "Lavel/Post Name")]
        public string LevelPost { get; set; }


        //[Required(ErrorMessage = "Please Enter Essential Qualificaton")]
        //[Display(Name = "Essential Qualification")]
        //public string EssentQualification { get; set; }

        //[Required(ErrorMessage = "Please Enter Desirable Qualificaton")]
        //[Display(Name = "Desirable Qualification")]
        //public string DesireQualificaton { get; set; }

        [Display(Name = "Work Experience (In Year)")]
        public int? WorkExperience { get; set; }

        [Display(Name = "Min Age")]
        public int? AgeMin { get; set; }

        [Required(ErrorMessage = "Please Enter Max Age")]
        [Display(Name = "Max Age")]
        public int AgeMax { get; set; }

        [Required(ErrorMessage = "Please Enter Job Location")]
        [Display(Name = "Job Location")]
        public string JobLocation { get; set; }

        [Required(ErrorMessage = "Please Enter Min Salary")]
        [Display(Name = "Min Salary")]
        public double SalaryMin { get; set; }

        [Required(ErrorMessage = "Please Enter Max Salary")]
        [Display(Name = "Max Salary")]
        public double SalaryMax { get; set; }

        [Display(Name = "Additional Benefit")]
        public string AdditionalBenefits { get; set; }

        [Required(ErrorMessage = "Please Enter Last Date")]
        [Display(Name = "Last Date")]
        public DateTime LastDate { get; set; }

        [Display(Name = "Mode of Application")]
        //public int ModeOfApplicationId { get; set; }
        public int? ModeOfApplicationId
        {
            get { return (int?)ModeOfApplication; }
            private set { ModeOfApplication = (ModeOfApplication)Enum.Parse(typeof(ModeOfApplication), Convert.ToString(value == null ? 0 : value), true); }
        }
        [NotMapped]
        public ModeOfApplication ModeOfApplication { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        [Display(Name = "Company Name")]
        public long CompanyId { get; set; }
        public virtual CompanyMaster Companys { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        [Display(Name = "State Name")]
        public long StateId { get; set; }
        public virtual StateMaster States { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        [Display(Name = "City Name")]
        public long CityId { get; set; }
        public virtual CityMaster Citys { get; set; }

        [Display(Name = "Grade")]
        [Required(ErrorMessage = "Please Enter Grade")]
        public int GradeId { get; set; }
        public virtual GradeMaster Grades { get; set; }

        [NotMapped]
        [Display(Name = "Qualification Type")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Qualification Type")]
        public VacancyType VacancyType { get; set; }
        //[NotMapped]
        //public int[] QualificationIds { get; set; }
    }
    public enum VacancyType
    {
        Select = 0,
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
    public class VacancyDetailsIndxVM : VacancyMasterVM
    {
        public VacancyDetailsIndxVM()
        {
            iQualificationDesirables = new List<QualificationMaster>();
            iQualificationEssentials = new List<QualificationMaster>();
        }
        public virtual ICollection<QualificationMaster> iQualificationDesirables { get; set; }
        public virtual ICollection<QualificationMaster> iQualificationEssentials { get; set; }
    }
    //public class VacancyDetailsIndxVM
    //{
    //    [Key]
    //    [Display(Name = "Vacancy Id")]
    //    public long VacancyId { get; set; }

    //    [Display(Name = "Vacancy Code")]
    //    public string VacancyCode { get; set; }

    //    [Display(Name = "Post Name")]
    //    public string PostName { get; set; }

    //    [Display(Name = "Job Function")]
    //    public string JobFunction { get; set; }

    //    [Display(Name = "Vacancy Type")]
    //    public string VacancyTypeString { get; set; }

    //    [Display(Name = "No of Vacancy")]
    //    public int Vacancies { get; set; }

    //    [Display(Name = "Level/Post Name")]
    //    public string LevelPost { get; set; }

    //    [Display(Name = "Work Experience (In Year)")]
    //    public int WorkExperience { get; set; }

    //    [Display(Name = "Min Age")]
    //    public int AgeMin { get; set; }

    //    [Display(Name = "Max Age")]
    //    public int AgeMax { get; set; }

    //    [Display(Name = "Job Location")]
    //    public string JobLocation { get; set; }

    //    [Display(Name = "Min Salary")]
    //    public double SalaryMin { get; set; }

    //    [Display(Name = "Max Salary")]
    //    public double SalaryMax { get; set; }

    //    [Display(Name = "Additional Benefit")]
    //    public string AdditionalBenefits { get; set; }

    //    [Display(Name = "Company Id")]
    //    public long CompanyId { get; set; }
    //    public virtual CompanyMaster Companys { get; set; }

    //    [Display(Name = "State Id")]
    //    public long StateId { get; set; }
    //    public virtual StateMaster States { get; set; }

    //    [Display(Name = "City Id")]
    //    public long CityId { get; set; }
    //    public virtual CityMaster Citys { get; set; }

    //    public VacancyDetailsIndxVM()
    //    {
    //        iQualificationDesirables = new List<QualificationMaster>();
    //        iQualificationEssentials = new List<QualificationMaster>();
    //    }
    //    public virtual ICollection<QualificationMaster> iQualificationDesirables { get; set; }
    //    public virtual ICollection<QualificationMaster> iQualificationEssentials { get; set; }

    //}
    public class VacancyDetailsCrtVM : VacancyMasterVM
    {
        public VacancyDetailsCrtVM()
        {
            iQualificationDesirables = new List<QualificationMaster>();
            iQualificationEssentials = new List<QualificationMaster>();
        }
        public virtual ICollection<QualificationMaster> iQualificationDesirables { get; set; }
        public virtual ICollection<QualificationMaster> iQualificationEssentials { get; set; }
    }
    public class VacancyDetailsUpVM : VacancyMasterVM
    {
        public VacancyDetailsUpVM()
        {
            iQualificationDesirables = new List<QualificationMaster>();
            iQualificationEssentials = new List<QualificationMaster>();
        }
        public virtual ICollection<QualificationMaster> iQualificationDesirables { get; set; }
        public virtual ICollection<QualificationMaster> iQualificationEssentials { get; set; }
    }
    //public class VacancyDetailsDeleteVM
    //{
    //    [Key]
    //    [Required(ErrorMessage = "Please Enter Vacancy Id")]
    //    [Display(Name = "Vacancy Id")]
    //    public long VacancyId { get; set; }
    //}

}