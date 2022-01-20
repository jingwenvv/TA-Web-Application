/*
Author: Jingwen Zhang
Partner: -Na-
Date: 2021/10/24
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
another source. Any references used in the completion of the assignment are cited in my README file.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TA__Application.Areas.Identity.Data;
using TA__Application.Data;
using TA__Application.Models;

namespace TA__Application
{
    [Authorize]
    public class AvailabilitiesController : Controller
    {
        private readonly TA_DB _context;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly UserManager<TAUser> _um;

        public AvailabilitiesController(TA_DB context, RoleManager<IdentityRole> rm,
            UserManager<TAUser> um)
        {
            _context = context;
            _context.TimeSlots = _context.InitiaTimeSlots();
            _um = um;
            _rm = rm;

        }

        private int GetAvaID(string userID)
        {
            foreach (var ava in _context.Availabilities)
            {
                if (ava.UserID == userID) return ava.ID;
            }
            return -1;
        }

        /// <summary>
        /// Methof to receive data from View when user click or drag some slots.
        /// </summary>
        /// <param name="before_x"></param>
        /// <param name="before_y"></param>
        /// <param name="m"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task ReceiveIndex(int before_x, int before_y, int m, string userID)
        {
            int i = (before_x - 240) / 200;
            int j = (before_y - 120) / 14;

            Availability ava = await _context.Availabilities.FirstOrDefaultAsync(m => m.UserID == userID);
            if (ava is null)
            {

                ava = new Availability()
                {
                    UserID = userID,
                    SlotsString = "",
                    pendingSlots = "",
                    hour = 0
                };
                StringBuilder sb = new StringBuilder();

                if (ava.pendingSlots is not null && ava.pendingSlots.Length > 2)
                {
                    sb.Append(ava.pendingSlots);
                }

                for (int k = 0; k < m; k++)
                {
                    int tempIndex1 = i;
                    int tempIndex2 = j + k;
                    sb.Append(tempIndex1.ToString() + "." + tempIndex2.ToString() + ",");
                }

                ava.pendingSlots = sb.ToString();
                _context.Add(ava);
                await _context.SaveChangesAsync();
            }
            // if the user have an Ava
            else
            {
                StringBuilder sb = new StringBuilder();
                if (ava.pendingSlots is not null && ava.pendingSlots.Length > 2)
                {
                    sb.Append(ava.pendingSlots);
                }
                for (int k = 0; k < m; k++)
                {
                    int tempIndex1 = i;
                    int tempIndex2 = j + k;
                    sb.Append(tempIndex1.ToString() + "." + tempIndex2.ToString() + ",");
                }
                ava.pendingSlots = sb.ToString();
                _context.Update(ava);
                await _context.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Find the app id by a userID, if the user has one.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        private int FindAppID(string userID)
        {
            foreach(Application app in _context.Applications)
            {
                if (app.UserID == userID) return app.ID;
            }
            return -1;
        }

        /// <summary>
        /// Clear all the pending slots stored in the DB
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task ClearPending(string userID)
        {
            Availability ava = await _context.Availabilities.FirstOrDefaultAsync(m => m.UserID == userID);
            ava.pendingSlots = "";
            _context.Update(ava);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Set the schedule by the pending string
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task SetSchedule(string userID)
        {
            Availability ava = await _context.Availabilities.FirstOrDefaultAsync(m => m.UserID == userID);
            Application app = await _context.Applications.FirstOrDefaultAsync(m => m.UserID == userID);
            // if the user does not have an Ava
            // means that there is no slots selected yet
            if (ava is null)
            {
                ava = new Availability()
                {
                    UserID = userID,
                    SlotsString = "",
                    hour = 0
                };
                _context.Add(ava);
                app.Availabilities = 0;
                _context.Update(app);
                await _context.SaveChangesAsync();
            }
            // if the user have an Ava
            else
            {
                string slotsString = GetSlotString(ava.SlotsString, ava.pendingSlots);
                ava.SlotsString = slotsString;
                double hour = GetSlotHour(slotsString);
                ava.hour = hour;
                ava.pendingSlots = "";
                _context.Update(ava);
                app.Availabilities = hour;
                _context.Update(app);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Calculate the total availability hour by a slot string
        /// </summary>
        /// <param name="slotString"></param>
        /// <returns></returns>
        public double GetSlotHour(string slotString)
        {
            double sum = 0;
            string[] tabs = slotString.Split(",");
            foreach(string s in tabs)
            {
                if (s.Length > 5) sum++;
            }
            return sum / 4;
        }

        /// <summary>
        /// Clear all the scheduled time and pending time
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task ResetSchedule(string userID)
        {
            Availability ava = await _context.Availabilities.FirstOrDefaultAsync(m => m.UserID == userID);
            Application app = await _context.Applications.FirstOrDefaultAsync(m => m.UserID == userID);
            // if the user does not have an Ava
            // means that there is no slots selected yet
            if (ava is null)
            {
                ava = new Availability()
                {
                    UserID = userID,
                    SlotsString = "",
                    hour = 0
                };
                _context.Add(ava);
                app.Availabilities = 0;
                _context.Update(app);
                await _context.SaveChangesAsync();
            }
            // if the user have an Ava
            else
            {
                ava.SlotsString = "";
                ava.pendingSlots = "";
                ava.hour = 0;
                _context.Update(ava);
                app.Availabilities = 0;
                _context.Update(app);
                await _context.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Get the time array by the time slots string
        /// </summary>
        /// <param name="slotString"></param>
        /// <returns></returns>
        public string[,] GetArrayFromSlotsString(string slotString)
        {
            string[,] preSlots = new string[5, 48];

            // if the string is null
            if (slotString is not null && slotString.Length > 5)
            {
                string[] tabs = slotString.Split(",");
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 48; j++)
                    {
                        preSlots[i, j] = tabs[i * 48 + j];
                    }
                }
            }

            return preSlots;
        }

        /// <summary>
        /// Merge the pending time and the previous scheduled time
        /// </summary>
        /// <param name="currentSlots"></param>
        /// <param name="pendingSlots"></param>
        /// <returns></returns>
        public string GetSlotString(string currentSlots, string pendingSlots)
        {
            if (pendingSlots.Length == 0)
            {
                return currentSlots;
            }
            else
            {
                string[] tabs = pendingSlots.Split(",");

                string[,] preSlots = GetArrayFromSlotsString(currentSlots);
                string[,] array = new string[5, 48];

                for (int m = 0; m < tabs.Length; m++)
                {
                    if (tabs[m].Length < 2) continue;
                    string[] index = tabs[m].Split(".");
                    int i = int.Parse(index[0]);
                    int j = int.Parse(index[1]);
                    array[i, j] = _context.TimeSlots[i, j];
                }
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 48; j++)
                    {
                        if (preSlots[i, j] is not null && preSlots[i, j].Length > 5)
                        {
                            sb.Append(preSlots[i, j] + ",");
                        }
                        else
                        {
                            sb.Append(array[i, j] + ",");
                        }
                    }
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Get ths scheduled time array by the Availability Object
        /// </summary>
        /// <param name="availability"></param>
        /// <returns></returns>
        public string[,] GetSchedule(Availability availability)
        {
            string[,] preSlots;
            // if the user has an exist Ava
            if (availability is not null)
            {
                preSlots = GetArrayFromSlotsString(availability.SlotsString);
            }
            // if the user does not has an Ava
            else
            {
                preSlots = new string[5, 48];
            }

            return preSlots;
        }

        /// <summary>
        /// The index entry point. Only accesss by valid applicant.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Applicant")]
        // GET: Availabilities
        public async Task<IActionResult> Index()
        {
            // get user id
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // if the applicant does have an application
            if (FindAppID(userID) == -1)
            {
                return RedirectToAction("IndexNoApp", "Applications");
            }

            // check if the user has a Ava
            var availability = await _context.Availabilities.FirstOrDefaultAsync(m => m.UserID == userID);
            string[,] preSlots = GetSchedule(availability);

            bool[] preAvas = new bool[240];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 48; j++)
                {
                    preAvas[i * 48 + j] = (preSlots[i, j] is not null && preSlots[i, j].Length > 5);
                }
            }
            ViewBag.preAvas = preAvas;
            ViewBag.userID = userID;
            ViewBag.access = true;
            return View();
        }

        /// <summary>
        /// The Details entry point.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Availabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            // check if the user has a Ava
            var application = await _context.Applications.FirstOrDefaultAsync(m => m.ID == id);
            var userID = application.UserID;
            var availability = await _context.Availabilities.FirstOrDefaultAsync(m => m.UserID == userID);
            string[,] preSlots = GetSchedule(availability);

            bool[] preAvas = new bool[240];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 48; j++)
                {
                    preAvas[i * 48 + j] = (preSlots[i, j] is not null && preSlots[i, j].Length > 5);
                }
            }

            ViewBag.name = application.FirstMidName.ToString() + " " + application.LastName.ToString();
            ViewBag.preAvas = preAvas;
            ViewBag.access = false;
            return View();
        }      
    }
}
