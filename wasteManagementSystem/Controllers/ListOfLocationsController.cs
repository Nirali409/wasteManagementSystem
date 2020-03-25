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
    public class ListOfLocationsController : Controller
    {
        private readonly wasteManagementContext _context;

        public ListOfLocationsController(wasteManagementContext context)
        {
            _context = context;
        }

        // GET: ListOfLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListOfLocation.ToListAsync());
        }

        // GET: ListOfLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfLocation = await _context.ListOfLocation
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (listOfLocation == null)
            {
                return NotFound();
            }

            return View(listOfLocation);
        }

        // GET: ListOfLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListOfLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,LocationName")] ListOfLocation listOfLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listOfLocation);
        }

        // GET: ListOfLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfLocation = await _context.ListOfLocation.FindAsync(id);
            if (listOfLocation == null)
            {
                return NotFound();
            }
            return View(listOfLocation);
        }

        // POST: ListOfLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,LocationName")] ListOfLocation listOfLocation)
        {
            if (id != listOfLocation.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfLocationExists(listOfLocation.LocationId))
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
            return View(listOfLocation);
        }

        // GET: ListOfLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfLocation = await _context.ListOfLocation
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (listOfLocation == null)
            {
                return NotFound();
            }

            return View(listOfLocation);
        }

        // POST: ListOfLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfLocation = await _context.ListOfLocation.FindAsync(id);
            _context.ListOfLocation.Remove(listOfLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfLocationExists(int id)
        {
            return _context.ListOfLocation.Any(e => e.LocationId == id);
        }
    }
}
