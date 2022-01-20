using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TA__Application.Models
{
    public enum SemesterOffered
    {
        Fall, Summer, Spring,
        [Display(Name = "Fall/Spring")] Fall_Spring
    }

    public enum Department
    {
        CS, CE, Comp
    }

    public enum DayOffered
    {
        M, Tu, W, Th, Fr, Sa, 
        [Display(Name ="M/W")] M_W,
        [Display(Name = "Tu/Th")] Tu_Th,
        [Display(Name = "M/W/Fr")] M_W_Fr
    }

    public class Course
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Course Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Course Number")]
        public string CourseNumber { get; set; }

        [Required]
        [Display(Name = "Class Number")]
        public string ClassNumber { get; set; }

        [Required]
        [Display(Name = "Course Section")]
        public string Section { get; set; }

        [Required]
        [Display(Name = "Catalog Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Professor UNID")]
        public string ProfessorUNID { get; set; }

        [Required]
        [Display(Name = "Professor Name")]
        public string ProfessorName { get; set; }

        [Required]
        [Display(Name = "Day Offered")]
        public DayOffered DayOffered { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public string TimeStart { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public string TimeEnd { get; set; }

        [Required]
        [Display(Name = "Semester Offered")]
        public SemesterOffered SemesterOffered { get; set; }

        [Required]
        [Display(Name = "Year Offered")]
        public string YearOffered { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Credit Hour")]
        public int CreditHour { get; set; }

        [Required]
        [Display(Name = "Enrollment Capacity")]
        public int EnrollmentCap { get; set; }

        [Required]
        [Display(Name = "Current Enrolled")]
        public int Enrolled { get; set; }

        public string Note { get; set; }


    }
}
