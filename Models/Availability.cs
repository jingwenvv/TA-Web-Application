/*
Author: Jingwen Zhang
Partner: -Na-
Date: 2021/11/28
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
another source. Any references used in the completion of the assignment are cited in my README file.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA__Application.Models
{
    public class Availability
    {
        public string UserID { get; set; }
        public int ID { get; set; }
       
        public string SlotsString { get; set; }

        public string pendingSlots  { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public double hour { get; set; }

    }
}