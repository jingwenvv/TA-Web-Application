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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TA__Application.Data;
using TA__Application.Models;

namespace TA__Application
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly TA_DB _context;

        public CoursesController(TA_DB context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator, Professor")]
        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        public async Task<IActionResult> Note_Update(int courseID, string newNote)
        {
            try
            {
                var course = await _context.Courses.FindAsync(courseID);
                course.Note = newNote;
                _context.Update(course);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "success" });

            }
            catch (Exception)
            {
                return BadRequest(new { success = false, message = "bad request" });
            }
        }

        public async Task<IActionResult> Note_Delete(int courseID)
        {
            try
            {
                var course = await _context.Courses.FindAsync(courseID);
                course.Note = "";
                _context.Update(course);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "success" });

            }
            catch (Exception)
            {
                return BadRequest(new { success = false, message = "bad request" });
            }
        }

        [AllowAnonymous]
        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,CourseNumber,ClassNumber,Section,Description,ProfessorUNID,ProfessorName,DayOffered,TimeStart,TimeEnd,SemesterOffered,YearOffered,Department,Location,CreditHour,EnrollmentCap,Enrolled,Note")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,CourseNumber,ClassNumber,Section,Description,ProfessorUNID,ProfessorName,DayOffered,TimeStart,TimeEnd,SemesterOffered,YearOffered,Department,Location,CreditHour,EnrollmentCap,Enrolled,Note")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }
    }
}
