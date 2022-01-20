/*
  Author:    Jingwen Zhang
  Partner:   -Na -
  Date:      2021 / 10 / 24
  Course: CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

  I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA__Application.Areas.Identity.Data;
using TA__Application.Data;
using TA__Application.Models;

namespace TA__Application.Data
{
    public static class SeedUsersRolesDB
    {
        public static async Task Initialize(TA_DB ta_db,
            TAUsersRolesDB user_db,
            UserManager<TAUser> um,
            RoleManager<IdentityRole> rm)
        {
            user_db.Database.EnsureCreated();
            ta_db.Database.EnsureCreated();

            ta_db.TimeSlots = ta_db.InitiaTimeSlots();

            await SeedRolesAsync(rm);
            await SeedUsersAsync(ta_db, user_db, um);

            ta_db.SaveChanges();
        }

        private static string GenerateSlots(TA_DB ta_db)
        {
            string[,] array = new string[5, 48];
            for (int j = 0; j < 16; j++)
            {
                array[0, j] = ta_db.TimeSlots[0, j];
                array[4, j] = ta_db.TimeSlots[4, j];
            }

            for (int j = 16; j < 36; j++)
            {
                array[1, j] = ta_db.TimeSlots[1, j];
                array[3, j] = ta_db.TimeSlots[3, j];
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 48; j++)
                {
                    sb.Append(array[i, j] + ",");
                }
            }

            return sb.ToString();
        }

        public static async Task SeedRolesAsync(RoleManager<IdentityRole> rm)
        {

            if (!rm.RoleExistsAsync("Administrator").Result)
            {
                await rm.CreateAsync(new IdentityRole("Administrator"));
            }

            if (!rm.RoleExistsAsync("Professor").Result)
            {
                await rm.CreateAsync(new IdentityRole("Professor"));
            }

            if (!rm.RoleExistsAsync("Applicant").Result)
            {
                await rm.CreateAsync(new IdentityRole("Applicant"));
            }
        }

        public static async Task SeedUsersAsync(TA_DB ta_db, TAUsersRolesDB user_db, UserManager<TAUser> um)
        {
            if (um.FindByNameAsync("admin@utah.edu").Result == null)
            {
                TAUser user1 = new TAUser
                {
                    UserName = "admin@utah.edu",
                    Email = "admin@utah.edu",
                    EmailConfirmed = true,
                    FirstName = "Mary",
                    LastName = "Hall",
                    UID = "admin",
                    Gender = Gender.Female
                };

                var result = await um.CreateAsync(user1, "123ABC!@#def");

                if (result.Succeeded)
                {
                    var result2 = await um.AddToRoleAsync(user1, "Administrator");
                }

            }

            if (um.FindByNameAsync("professor@utah.edu").Result == null)
            {
                TAUser user2 = new TAUser
                {
                    UserName = "professor@utah.edu",
                    Email = "professor@utah.edu",
                    EmailConfirmed = true,
                    FirstName = "John",
                    LastName = "Regehr",
                    UID = "professor",
                    Gender = Gender.Male
                };


                IdentityResult result = um.CreateAsync(user2, "123ABC!@#def").Result;

                if (result.Succeeded)
                {
                    await um.AddToRoleAsync(user2, "Professor");
                }
            }

            if (um.FindByNameAsync("u0000000@utah.edu").Result == null)
            {
                TAUser user3 = new TAUser
                {
                    UserName = "u0000000@utah.edu",
                    Email = "u0000000@utah.edu",
                    EmailConfirmed = true,
                    FirstName = "Christopher",
                    LastName = "Smith",
                    UID = "u0000000",
                    Gender = Gender.Male
                };

                IdentityResult result = um.CreateAsync(user3, "123ABC!@#def").Result;

                if (result.Succeeded)
                {
                    await um.AddToRoleAsync(user3, "Applicant");
                }

                var app1 = new Application
                {
                    UserID = user3.Id,
                    FirstMidName = "Christopher",
                    LastName = "Smith",
                    UID = "u0000000",
                    PhoneNumber = "801-123-4567",
                    Address = "201 Presidents' Cir, Salt Lake City, UT 84112",
                    Degree = Degree.MS,
                    Program = Models.Program.ME,
                    GPA = 3.8,
                    PersonalStatement = "-Na-",
                    EnglishFluency = EnglishFluency.Adequate,
                    Semesters = 2,
                    LinkedInURL = "https://www.linkedin.com",
                    Resume = "-Na-",
                    CreationDate = DateTime.Parse("2021-09-02"),
                    ModificationDate = DateTime.Parse("2021-09-21"),
                    Availabilities = 18
                };

                ta_db.Applications.Add(app1);
                
                var ava1 = new Availability
                {
                    UserID = user3.Id,
                    SlotsString = GenerateSlots(ta_db),
                    pendingSlots = "0.0,0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,0.10,0.11,0.12,4.0,4.2,4.3,4.4,4.5,4.6,4.7,4.8,4.9,4.10,4.11,4.12,1.16," +
                    "1.17,1.18,1.19,1.20,1.21,1.22,1.23,1.24,1.25,1.26,1.27,1.28,1.29,1.30,1.31,1.32,1.33,1.34,1.35,3.16,3.17,3.18,3.19,3.20,3.21,3.22," +
                    "3.23,3.24,3.25,3.26,3.27,3.28,3.29,3.30,3.31,3.32,3.33,3.34,3.35,",
                    hour = 18
                };
                ta_db.Availabilities.Add(ava1);
            }

            if (um.FindByNameAsync("u0000001@utah.edu").Result == null)
            {
                TAUser user4 = new TAUser
                {
                    UserName = "u0000001@utah.edu",
                    Email = "u0000001@utah.edu",
                    EmailConfirmed = true,
                    FirstName = "Carson",
                    LastName = "Alexander",
                    UID = "u0000001",
                    Gender = Gender.Male
                };

                var result = um.CreateAsync(user4, "123ABC!@#def").Result;

                if (result.Succeeded)
                {
                    await um.AddToRoleAsync(user4, "Applicant");
                }

                var app2 = new Application
                {
                    UserID = user4.Id,
                    FirstMidName = "Carson",
                    LastName = "Alexander",
                    UID = "u0000001",
                    PhoneNumber = "801-123-4567",
                    Address = "201 Presidents' Cir, Salt Lake City, UT 84112",
                    Degree = Degree.BS,
                    Program = Models.Program.CS,
                    GPA = 4.0,
                    PersonalStatement = "-Na-",
                    EnglishFluency = EnglishFluency.Native,
                    Semesters = 4,
                    LinkedInURL = "https://www.linkedin.com",
                    Resume = "-Na-",
                    CreationDate = DateTime.Parse("2021-09-01"),
                    ModificationDate = DateTime.Parse("2021-09-21"),
                    Availabilities = 18
                };

                ta_db.Applications.Add(app2);

                var ava2 = new Availability
                {
                    UserID = user4.Id,
                    SlotsString = GenerateSlots(ta_db),
                    pendingSlots = "0.0,0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,0.10,0.11,0.12,4.0,4.2,4.3,4.4,4.5,4.6,4.7,4.8,4.9,4.10,4.11,4.12,1.16," +
                    "1.17,1.18,1.19,1.20,1.21,1.22,1.23,1.24,1.25,1.26,1.27,1.28,1.29,1.30,1.31,1.32,1.33,1.34,1.35,3.16,3.17,3.18,3.19,3.20,3.21,3.22," +
                    "3.23,3.24,3.25,3.26,3.27,3.28,3.29,3.30,3.31,3.32,3.33,3.34,3.35,",
                    hour = 18
                };
                ta_db.Availabilities.Add(ava2);

            }

            if (um.FindByNameAsync("u0000002@utah.edu").Result == null)
            {
                TAUser user5 = new TAUser
                {
                    UserName = "u0000002@utah.edu",
                    Email = "u0000002@utah.edu",
                    EmailConfirmed = true,
                    FirstName = "Meredith",
                    LastName = "Alonso",
                    UID = "u0000002",
                    Gender = Gender.Male
                };

                IdentityResult result = um.CreateAsync
                (user5, "123ABC!@#def").Result;

                if (result.Succeeded)
                {
                    await um.AddToRoleAsync(user5, "Applicant");
                }


                var app = new Application
                {
                    UserID = user5.Id,
                    FirstMidName = "Meredith",
                    LastName = "Alonso",
                    UID = "u0000002",
                    PhoneNumber = "801-123-4567",
                    Address = "201 Presidents' Cir, Salt Lake City, UT 84112",
                    Degree = Degree.MS,
                    Program = Models.Program.ME,
                    GPA = 3.8,
                    PersonalStatement = "-Na-",
                    EnglishFluency = EnglishFluency.Adequate,
                    Semesters = 2,
                    LinkedInURL = "https://www.linkedin.com",
                    Resume = "-Na-",
                    CreationDate = DateTime.Parse("2021-09-02"),
                    ModificationDate = DateTime.Parse("2021-09-21")
                };
                ta_db.Applications.Add(app);

            }
        }



        private static bool AppExist(TA_DB ta_db, TAUser user5)
        {
            foreach (Application a in ta_db.Applications)
            {
                if (a.UID == user5.UID) return true;
            }
            return false;
        }


    }
}