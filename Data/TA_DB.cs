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
using System.Linq;
using System.Threading.Tasks;
using TA__Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace TA__Application.Data
{
    public class TA_DB : DbContext
    {
        public TA_DB(DbContextOptions<TA_DB> options) : base(options)
        {
        }
        public string[,] TimeSlots;
        public DbSet<Application> Applications { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TimeSlots = InitiaTimeSlots();
            modelBuilder.Entity<Application>().ToTable("Application");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Availability>().ToTable("Availability");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        }


        public string[,] InitiaTimeSlots()
        {
            string[,] slots = new string[5, 48];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 48; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    switch (i)
                    {
                        case 0:
                            sb.Append("Monday ");
                            break;
                        case 1:
                            sb.Append("Tuesday ");
                            break;
                        case 2:
                            sb.Append("Wednesday ");
                            break;
                        case 3:
                            sb.Append("Thursday ");
                            break;
                        case 4:
                            sb.Append("Friday ");
                            break;
                        default:
                            sb.Append("Error!");
                            break;
                    }

                    int hour;
                    if (j < 16) // am
                    {
                        hour = j / 4 + 8;
                        sb.Append(hour + ":");
                        GenerateMinute(sb, j);
                        sb.Append("am");
                    }
                    else // pm
                    {
                        hour = j / 4 - 4;
                        sb.Append(hour + ":");
                        GenerateMinute(sb, j);
                        sb.Append("pm");
                    }

                    slots[i, j] = sb.ToString();
                }
            }

            return slots;
        }

        private void GenerateMinute(StringBuilder sb, int j)
        {
            switch (j % 4)
            {
                case 0:
                    sb.Append("00 ");
                    break;
                case 1:
                    sb.Append("15 ");
                    break;
                case 2:
                    sb.Append("30 ");
                    break;
                case 3:
                    sb.Append("45 ");
                    break;
                default:
                    sb.Append("Error!");
                    break;
            }
        }
    }
}
