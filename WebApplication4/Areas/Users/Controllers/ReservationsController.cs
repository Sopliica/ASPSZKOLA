using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.DB;
using WebApplication4.Models;

namespace WebApplication4.Areas.Users.Controllers;

[Area("Users")]
public class ReservationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReservationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Users/Reservations
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Reservation.Include(r => r.Vehicle);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Users/Reservations/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Reservation == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservation
            .Include(r => r.Vehicle)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }

        return View(reservation);
    }

    // GET: Users/Reservations/Create
    public IActionResult Create()
    {
        ViewData["VehicleId"] = new SelectList(_context.Set<Vehicle>(), "Id", "Id");
        return View();
    }

    // POST: Users/Reservations/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,reservationStart,reservationEnd,VehicleId")] Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _context.Add(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["VehicleId"] = new SelectList(_context.Set<Vehicle>(), "Id", "Id", reservation.VehicleId);
        return View(reservation);
    }

    // GET: Users/Reservations/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Reservation == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservation.FindAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }
        ViewData["VehicleId"] = new SelectList(_context.Set<Vehicle>(), "Id", "Id", reservation.VehicleId);
        return View(reservation);
    }

    // POST: Users/Reservations/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,reservationStart,reservationEnd,VehicleId")] Reservation reservation)
    {
        if (id != reservation.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(reservation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(reservation.Id))
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
        ViewData["VehicleId"] = new SelectList(_context.Set<Vehicle>(), "Id", "Id", reservation.VehicleId);
        return View(reservation);
    }

    // GET: Users/Reservations/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Reservation == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservation
            .Include(r => r.Vehicle)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }

        return View(reservation);
    }

    // POST: Users/Reservations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Reservation == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Reservation'  is null.");
        }
        var reservation = await _context.Reservation.FindAsync(id);
        if (reservation != null)
        {
            _context.Reservation.Remove(reservation);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReservationExists(int id)
    {
      return (_context.Reservation?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
