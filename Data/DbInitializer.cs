/*
Author: Jingwen Zhang
Partner: -Na-
Date: 2021/9/28
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
another source. Any references used in the completion of the assignment are cited in my README file.
*/

using TA__Application.Models;
using System;
using System.Linq;
using TA__Application.Data;
using System.Text;
using System.Threading.Tasks;

namespace TA__Application.Data
{
    public static class DbInitializer
    {
        
        public static void Initialize(TA_DB context)
        {
            context.Database.EnsureCreated();
            
            TA_DB_Initializer tb = new TA_DB_Initializer();
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }
            foreach (Course c in tb.courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
            if (context.Enrollments.Any())
            {
                return;   // DB has been seeded
            }

            foreach (Enrollment e in tb.enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }

       

        private static int FindCourseID(TA_DB context, string dept, string courseNum)
        {
            foreach (Course c in context.Courses.ToArray())
            {
                if (c.Department.ToString() == dept)
                {
                    if (c.CourseNumber == courseNum)
                    {
                        return c.ID;
                    }
                }
            }
            throw new NullReferenceException();
        }
    }
}