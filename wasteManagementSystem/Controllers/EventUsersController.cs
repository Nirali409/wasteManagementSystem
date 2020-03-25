using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wasteManagementSystem.Models;

namespace wasteManagementSystem.Controllers
{
    public class EventUsersController : Controller
    {
        private readonly wasteManagementContext _context;

        public EventUsersController(wasteManagementContext context)
        {
            _context = context;
        }

        // GET: EventUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventUser.ToListAsync());
        }

        // GET: EventUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventUser = await _context.EventUser
                .FirstOrDefaultAsync(m => m.EventUserId == id);
            if (eventUser == null)
            {
                return NotFound();
            }

            return View(eventUser);
        }

        // GET: EventUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventUserId,FirstName,LastName")] EventUser eventUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventUser);
        }

        // GET: EventUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventUser = await _context.EventUser.FindAsync(id);
            if (eventUser == null)
            {
                return NotFound();
            }
            return View(eventUser);
        }

        // POST: EventUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventUserId,FirstName,LastName")] EventUser eventUser)
        {
            if (id != eventUser.EventUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventUserExists(eventUser.EventUserId))
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
            return View(eventUser);
        }

        // GET: EventUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventUser = await _context.EventUser
                .FirstOrDefaultAsync(m => m.EventUserId == id);
            if (eventUser == null)
            {
                return NotFound();
            }

            return View(eventUser);
        }

        // POST: EventUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventUser = await _context.EventUser.FindAsync(id);
            _context.EventUser.Remove(eventUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventUserExists(int id)
        {
            return _context.EventUser.Any(e => e.EventUserId == id);
        }
    }
}
