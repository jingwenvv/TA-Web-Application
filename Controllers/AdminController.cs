/*
Author: Jingwen Zhang
Partner: -Na-
Date: 2021/10/24
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
another source. Any references used in the completion of the assignment are cited in my README file.
*/

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA__Application.Areas.Identity.Data;
using TA__Application.Data;
using TA__Application.Models;

namespace TA__Application.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _rm;
        private readonly UserManager<TAUser> _um;
        private readonly TA_DB _context;
        public AdminController(RoleManager<IdentityRole> rm,
            UserManager<TAUser> um, TA_DB context)
        {
            _um = um;
            _rm = rm;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ListUserRole()
        {
            ViewBag.roles = _rm.Roles.ToList();
            ViewBag.users = _um.Users.ToList();
            ViewBag.um = _um;
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Chart()
        {
            ViewBag.enrollments = _context.Enrollments.ToList();
            return View();
        }
        public IActionResult DarkChart()
        {
            ViewBag.enrollments = _context.Enrollments.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetEnrollmentDataAsync(string start, string end, string course, int days)
        {
            string[] startTabs = start.Split("/");
            string[] endTabs = end.Split("/");
            int startM = Int32.Parse(startTabs[0]);
            int endM = Int32.Parse(endTabs[0]);
            int startD = Int32.Parse(startTabs[1]);
            int endD = Int32.Parse(endTabs[1]);
            DateTime sd;
            DateTime ed;
            try
            {
                sd = new DateTime(2021, startM, startD);
                ed = new DateTime(2021, endM, endD);
            }catch(Exception)
            {
                sd = new DateTime(2021, startM+1, 1);
                ed = new DateTime(2021, 12, 11);
            }
            Enrollment e = await _context.Enrollments.FirstOrDefaultAsync(m => m.course == course);

            if (e is null)
            {
                return Ok(new int[days]);
            }
            else
            {
                string s = e.dateEnrollString;
                List<KeyValuePair<String, int>> list = GetListFromString(s);
                string[] sd2tabs = list[0].Key.Split("/");
                string[] ed2tabs = list[list.Count - 1].Key.Split("/");
                int startM2 = Int32.Parse(sd2tabs[0]);
                int endM2 = Int32.Parse(ed2tabs[0]);
                int startD2 = Int32.Parse(sd2tabs[1]);
                int endD2 = Int32.Parse(ed2tabs[1]);
                DateTime sd2 = new DateTime(2021, startM2, startD2);
                DateTime ed2 = new DateTime(2021, endM2, endD2);

                int edays = list.Count;
                if (DateTime.Compare(ed, sd2) <= 0)
                {
                    return Ok(new int[days]);
                }
                else if (DateTime.Compare(ed2, sd) <= 0)
                {
                    int num = list[list.Count - 1].Value;
                    int[] array = new int[days];
                    for (int i = 0; i < days; i++)
                    {
                        array[i] = num;
                    }
                    return Ok(array);
                }
                else if (DateTime.Compare(sd, sd2) <= 0 && DateTime.Compare(ed2, ed) <= 0)
                {
                    int earlyDays = (sd2 - sd).Days;
                    int lateDays = (ed - ed2).Days;
                    int totalDays = earlyDays + edays + lateDays;
                    int[] array = new int[totalDays];
                    for (int i = 0; i < totalDays; i++)
                    {
                        if (i <= earlyDays)
                        {
                            array[i] = 0;
                        }
                        else if (i >= earlyDays + edays)
                        {
                            array[i] = list[list.Count - 1].Value;
                        }
                        else
                        {
                            array[i] = list[i - earlyDays].Value;
                        }
                    }
                    return Ok(array);
                }
                else if (DateTime.Compare(sd, sd2) <= 0 && DateTime.Compare(ed, ed2) <= 0)
                {
                    int earlyDays = (sd2 - sd).Days;
                    int lateDays = (ed2 - ed).Days;
                    int totalDays = earlyDays + edays - lateDays;
                    int[] array = new int[totalDays];
                    for (int i = 0; i < totalDays; i++)
                    {
                        if (i >= -earlyDays + edays)
                        {
                            array[i] = 0;
                        }
                        else
                        {
                            array[i] = list[i + earlyDays].Value;
                        }
                    }
                    return Ok(array);
                }
                else if (DateTime.Compare(sd2, sd) <= 0 && DateTime.Compare(ed2, ed) <= 0)
                {
                    int earlyDays = (sd - sd2).Days;
                    int lateDays = (ed - ed2).Days;
                    int totalDays = -earlyDays + edays + lateDays;
                    int[] array = new int[totalDays];
                    for (int i = 0; i < totalDays; i++)
                    {
                        if (i >= -earlyDays + edays)
                        {
                            array[i] = list[list.Count - 1].Value;
                        }
                        else
                        {
                            array[i] = list[i + earlyDays].Value;
                        }
                    }
                    return Ok(array);
                }
                else
                {
                    int[] array = new int[days + 1];
                    for (int i = 0; i < days + 1; i++)
                    {

                        array[i] = list[i+startD].Value;

                    }
                    return Ok(array);
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> Change_Role(string userID, string role)
        {
            try
            {
                var user = await _um.FindByIdAsync(userID);
                var currentRole = await _um.GetRolesAsync(user);
                foreach (string r in currentRole)
                {
                    await _um.RemoveFromRoleAsync(user, r);
                }
                await _um.AddToRoleAsync(user, role);

                return Ok(new { success = true, message = "success" });
            }
            catch (Exception)
            {
                return BadRequest(new { success = false, message = "bad request" });
            }
        }

        /// <summary>
        /// Given a string from the Enrollment object, return a list contains 
        /// the date and corresponding enrollment number.
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public List<KeyValuePair<String, int>> GetListFromString(string dateString)
        {
            List<KeyValuePair<String, int>> list = new List<KeyValuePair<String, int>>();

            if (dateString is not null && dateString.Length > 5)
            {
                string[] tabs = dateString.Split(",");
                for (int i = 0; i < tabs.Length; i++)
                {
                    string[] rawValue = tabs[i].Split(".");
                    string date = rawValue[0];
                    int num = Int32.Parse(rawValue[1]);
                    list.Add(new KeyValuePair<string, int>(date, num));
                }
            }
            return list;
        }

        /// <summary>
        /// Given a list, return a string concating all the items inside.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetStringFromList(List<KeyValuePair<String, int>> list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                KeyValuePair<String, int> p = list[i];

                if (i == list.Count - 1)
                {
                    sb.Append(p.Key.ToString() + "." + p.Value.ToString());
                }
                else
                {
                    sb.Append(p.Key.ToString() + "." + p.Value.ToString() + ",");
                }

            }
            return sb.ToString();
        }


    }
}
