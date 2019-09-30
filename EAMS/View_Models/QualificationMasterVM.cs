using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMS.View_Models
{
    //public class QualificationMasterVM
    //{
    //    [Key]
    //    public long QualificationId { get; set; }
    //    [Required(ErrorMessage = "Please Enter Qualification Type")]
    //    [Display(Name = "Qualification Type")]
    //    [Column("QualificationType")]
    //    public string QualificationTypeString
    //    {
    //        get { return QualificationType.ToString(); }
    //        private set { QualificationType = value.ParseEnum<QualificationType>(); }
    //    }

    //    [Required(ErrorMessage = "Please Enter Qualification Level")]
    //    [Display(Name = "Qualification Level")]
    //    [Column("QualificationLevel")]
    //    public string QualificationLevelString
    //    {
    //        get { return QualificationLevel.ToString(); }
    //        private set { QualificationLevel = value.ParseEnum<QualificationLevel>(); }
    //    }

    //    [Required(ErrorMessage = "Please Enter Qualification")]
    //    [Display(Name = "Qualification")]
    //    public string Qualification { get; set; }

    //    [NotMapped]
    //    [Display(Name = "Qualification Type")]
    //    [Range(1, int.MaxValue, ErrorMessage = "Select Qualification Type")]
    //    public QualificationType QualificationType { get; set; }

    //    [NotMapped]
    //    [Display(Name = "Qualification Level")]
    //    [Range(1, int.MaxValue, ErrorMessage = "Select Qualification Level")]
    //    public QualificationLevel QualificationLevel { get; set; }
    //}
    public class QualificationMasterVM
    {
        [Key]
        public long QualificationId { get; set; }
        [Required(ErrorMessage = "Please Enter Qualification Type")]
        [Display(Name = "Qualification Type")]
        [Column("QualificationType")]
        public string QualificationTypeString
        {
            get { return QualificationType.ToString(); }
            private set { QualificationType = value.ParseEnum<QualificationType>(); }
        }

        [Required(ErrorMessage = "Please Enter Qualification Level")]
        [Display(Name = "Qualification Level")]
        [Column("QualificationLevel")]
        public string QualificationLevelString
        {
            get { return QualificationLevel.ToString(); }
            private set { QualificationLevel = value.ParseEnum<QualificationLevel>(); }
        }

        [Required(ErrorMessage = "Please Enter Qualification")]
        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [NotMapped]
        [Display(Name = "Qualification Type")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Qualification Type")]
        public QualificationType QualificationType { get; set; }

        [NotMapped]
        [Display(Name = "Qualification Level")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Qualification Level")]
        public QualificationLevel QualificationLevel { get; set; }
    }
    public class QualificationMasterIndxVM
    {
        [Key]
        public long QualificationId { get; set; }
        [Display(Name = "Qualification Type")]
        public string QualificationTypeString { get; set; }

        [Display(Name = "Qualification Level")]
        public string QualificationLevelString { get; set; }

        [Display(Name = "Qualification")]
        public string Qualification { get; set; }
    }
    public class QualificationMasterCrtVM : QualificationMasterVM
    {

    }
    public class QualificationMasterUpVM : QualificationMasterVM
    {

    }
    public class QualificationMasterDelVM
    {
        [Key]
        public long QualificationId { get; set; }
    }
    public enum QualificationLevel
    {
        Select = 0,
        Matric,
        Intermediate,
        Graduate,
        [Display(Name = "Post Graduate")]
        Post_Graduate
    }
    public enum QualificationType
    {
        Select = 0,
        Army,
        Civil,
        [Display(Name = "MGT")]
        Mgt,
        Technical
    }
}