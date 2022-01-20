/*
Author: Jingwen Zhang
Partner: -Na-
Date: 2021/9/28
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
another source. Any references used in the completion of the assignment are cited in my README file.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TA__Application.Models
{
    public enum EnglishFluency
    {
        Native, Fluent, Adequate, Poor, None
    }

    public enum Degree
    {
        BS, MS, PHD
    }

    public enum Program
    {
        CS, CE, ME
    }

    public enum Status
    {
        Assigned, Underconsidering
    }

    public class Application
    {
        public string UserID { get; set; }
        public int ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [Required]
        [StringLength(8)]
        public string UID { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        public Degree Degree { get; set; }       
        public Program Program { get; set; }
        [Range(0, 4.0)]
        public double GPA { get; set; }
        
        [Display(Name = "Personal Statement")]
        public string PersonalStatement { get; set; }
        [Display(Name ="English Fluency")]
        public EnglishFluency EnglishFluency { get; set; }
        [Display(Name = "Semesters completed")]
        public int Semesters { get; set; }
        [Display(Name = "Update LinkedIn URL")]
        public string LinkedInURL { get; set; }
        public string Resume { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Modification Date")]
        public DateTime ModificationDate { get; set; }

        public double Availabilities { get; set; }

    }
}
