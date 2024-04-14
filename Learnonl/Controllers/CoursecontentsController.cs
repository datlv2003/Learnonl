using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Learnonl.Data;
using static Learnonl.Models.Login;

namespace Learnonl.Controllers
{
    public class CoursecontentsController : Controller
    {
        private readonly LearnonlContext _context;

        public CoursecontentsController(LearnonlContext context)
        {
            _context = context;
        }

        // GET: Coursecontents
        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetString("UserRole");

            // Kiểm tra xem người dùng có vai trò Admin hay không
            if (userRole != "Admin")
            {
                // Nếu không phải Admin, chuyển hướng về trang Index của Home
                return RedirectToAction("Index", "Home");
            }
            var learnonlContext = _context.Coursecontents.Include(c => c.Lesson);
            return View(await learnonlContext.ToListAsync());
        }

        // GET: Coursecontents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursecontent = await _context.Coursecontents
                .Include(c => c.Lesson)
                .FirstOrDefaultAsync(m => m.CoursecontentId == id);
            if (coursecontent == null)
            {
                return NotFound();
            }

            return View(coursecontent);
        }

        // GET: Coursecontents/Create
        public IActionResult Create()
        {
            ViewData["LessonId"] = new SelectList(_context.Lessons, "LessonId", "LessonId");
            return View();
        }

        // POST: Coursecontents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoursecontentId,LessonId,Subjecttitle,LessoncontentId")] Coursecontent coursecontent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursecontent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = new SelectList(_context.Lessons, "LessonId", "LessonId", coursecontent.LessonId);
            return View(coursecontent);
        }

        // GET: Coursecontents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursecontent = await _context.Coursecontents.FindAsync(id);
            if (coursecontent == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = new SelectList(_context.Lessons, "LessonId", "LessonId", coursecontent.LessonId);
            return View(coursecontent);
        }

        // POST: Coursecontents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoursecontentId,LessonId,Subjecttitle,LessoncontentId")] Coursecontent coursecontent)
        {
            if (id != coursecontent.CoursecontentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursecontent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursecontentExists(coursecontent.CoursecontentId))
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
            ViewData["LessonId"] = new SelectList(_context.Lessons, "LessonId", "LessonId", coursecontent.LessonId);
            return View(coursecontent);
        }

        // GET: Coursecontents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursecontent = await _context.Coursecontents
                .Include(c => c.Lesson)
                .FirstOrDefaultAsync(m => m.CoursecontentId == id);
            if (coursecontent == null)
            {
                return NotFound();
            }

            return View(coursecontent);
        }

        // POST: Coursecontents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coursecontent = await _context.Coursecontents.FindAsync(id);
            if (coursecontent != null)
            {
                _context.Coursecontents.Remove(coursecontent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursecontentExists(int id)
        {
            return _context.Coursecontents.Any(e => e.CoursecontentId == id);
        }
    }
}
