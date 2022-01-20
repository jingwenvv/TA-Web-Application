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
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TA__Application.Data;
using TA__Application.Models;
using Microsoft.AspNetCore.Identity;
using TA__Application.Areas.Identity.Data;

namespace TA__Application.Controllers
{
    [Authorize]
    public class ApplicationsController : Controller
    {
        private readonly TA_DB _context;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly UserManager<TAUser> _um;

        public ApplicationsController(TA_DB context, RoleManager<IdentityRole> rm,
            UserManager<TAUser> um)
        {
            _context = context;
            _um = um;
            _rm = rm;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.IsInRole("Administrator"))
            {
                return View(await _context.Applications.ToListAsync());
            }
            else if (HttpContext.User.IsInRole("Professor"))
            {
                return RedirectToAction("IndexProfessor", "Applications");
            }
            else if (HttpContext.User.IsInRole("Applicant"))
            {
                var appId = GetAppID();
                if (appId != -1)
                {
                    return RedirectToAction("IndexWithApp", "Applications", new { appId });
                }

                return RedirectToAction("IndexNoApp", "Applications");
            }
            return RedirectToAction("IndexNonLogged", "Applications");
        }

        [Authorize(Roles = "Professor")]
        public IActionResult IndexProfessor()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult IndexNonLogged()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize(Roles = "Applicant")]
        public IActionResult IndexWithApp(int? ID)
        {
            ViewBag.app = ID;
            return View();
        }

        [Authorize(Roles = "Applicant")]
        public IActionResult IndexNoApp()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, Professor")]
        // GET: Applications
        public async Task<IActionResult> List()
        {
            ViewBag.Applications = await _context.Applications.ToListAsync();
            return View(await _context.Applications.ToListAsync());
        }

        [Authorize(Roles = "Administrator, Applicant")]
        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (HttpContext.User.IsInRole("Applicant") && GetAppID() != id)
            {
                return RedirectToAction("AccessDenied", "Applications");
            }

            var application = await _context.Applications
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        private int GetAppID()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            foreach (var app in _context.Applications)
            {
                if (app.UserID == userId) return app.ID;
            }
            return -1;
        }

        [Authorize(Roles = "Applicant")]
        // GET: Applications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Applicant")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastName,FirstMidName,UID,PhoneNumber,Address,Degree,Program,GPA,Hour,PersonalStatement,EnglishFluency,Semesters,LinkedInURL,Resume")] Application application)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    application.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _context.Add(application);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Applications", new { application.ID });
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (HttpContext.User.IsInRole("Applicant") && GetAppID() != id)
            {
                return RedirectToAction("AccessDenied", "Applications");
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        [Authorize(Roles = "Administrator, Applicant")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var applicationToUpdate = await _context.Applications.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Application>(
                applicationToUpdate,
                "",
                s => s.FirstMidName, s => s.LastName, s => s.UID,
                s => s.PhoneNumber, s => s.Address, s => s.Degree,
                s => s.Program, s => s.GPA, s => s.PersonalStatement,
                s => s.EnglishFluency, s => s.Semesters, s => s.LinkedInURL,
                s => s.Resume, s => s.CreationDate, s => s.ModificationDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Applications", new { applicationToUpdate.ID });
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(applicationToUpdate);
        }

        [Authorize(Roles = "Administrator, Applicant")]
        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        [Authorize(Roles = "Administrator, Applicant")]
        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }



        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ID == id);
        }
    }
}
