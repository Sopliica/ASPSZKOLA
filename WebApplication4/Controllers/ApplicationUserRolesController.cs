using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.DB;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ApplicationUserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUserRoles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserRoles.Include(a => a.Role).Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApplicationUserRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var applicationUserRole = await _context.UserRoles
                .Include(a => a.Role)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (applicationUserRole == null)
            {
                return NotFound();
            }

            return View(applicationUserRole);
        }

        // GET: ApplicationUserRoles/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ApplicationUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] ApplicationUserRole applicationUserRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUserRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", applicationUserRole.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", applicationUserRole.UserId);
            return View(applicationUserRole);
        }

        // GET: ApplicationUserRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var applicationUserRole = await _context.UserRoles.FindAsync(id);
            if (applicationUserRole == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", applicationUserRole.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", applicationUserRole.UserId);
            return View(applicationUserRole);
        }

        // POST: ApplicationUserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,RoleId")] ApplicationUserRole applicationUserRole)
        {
            if (id != applicationUserRole.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUserRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserRoleExists(applicationUserRole.UserId))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", applicationUserRole.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", applicationUserRole.UserId);
            return View(applicationUserRole);
        }

        // GET: ApplicationUserRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var applicationUserRole = await _context.UserRoles
                .Include(a => a.Role)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (applicationUserRole == null)
            {
                return NotFound();
            }

            return View(applicationUserRole);
        }

        // POST: ApplicationUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserRoles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserRoles'  is null.");
            }
            var applicationUserRole = await _context.UserRoles.FindAsync(id);
            if (applicationUserRole != null)
            {
                _context.UserRoles.Remove(applicationUserRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserRoleExists(string id)
        {
          return (_context.UserRoles?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
