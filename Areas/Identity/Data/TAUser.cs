/*
  Author:    Jingwen Zhang
  Partner:   -Na -
  Date:      2021 / 10 / 24
  Course: CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

  I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TA__Application.Areas.Identity.Data
{
    public enum Gender
    {
        Female, [Display(Name = "Female Presenting")]Female_Presenting, 
        Male, [Display(Name = "Male Presenting")] Male_Presenting,
        [Display(Name = "Non Binary")] Non_Binary, Intersex, [Display(Name = "Prefer Not to Say")] Prefer_Not_to_Say
    }
    // Add profile data for application users by adding properties to the TAUser class
    public class TAUser : IdentityUser
    {
        [Required]
        public string UID { get; set; }
        [Required]
        public Gender Gender { get; set; }
        
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
    }
}
