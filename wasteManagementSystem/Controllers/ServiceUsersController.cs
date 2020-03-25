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
    public class ServiceUsersController : Controller
    {
        private readonly wasteManagementContext _context;

        public ServiceUsersController(wasteManagementContext context)
        {
            _context = context;
        }

        // GET: ServiceUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceUser.ToListAsync());
        }

        // GET: ServiceUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceUser = await _context.ServiceUser
                .FirstOrDefaultAsync(m => m.ServiceUserId == id);
            if (serviceUser == null)
            {
                return NotFound();
            }

            return View(serviceUser);
        }

        // GET: ServiceUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceUserId,FirstName,LastName")] ServiceUser serviceUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceUser);
        }

        // GET: ServiceUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceUser = await _context.ServiceUser.FindAsync(id);
            if (serviceUser == null)
            {
                return NotFound();
            }
            return View(serviceUser);
        }

        // POST: ServiceUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceUserId,FirstName,LastName")] ServiceUser serviceUser)
        {
            if (id != serviceUser.ServiceUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceUserExists(serviceUser.ServiceUserId))
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
            return View(serviceUser);
        }

        // GET: ServiceUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceUser = await _context.ServiceUser
                .FirstOrDefaultAsync(m => m.ServiceUserId == id);
            if (serviceUser == null)
            {
                return NotFound();
            }

            return View(serviceUser);
        }

        // POST: ServiceUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceUser = await _context.ServiceUser.FindAsync(id);
            _context.ServiceUser.Remove(serviceUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceUserExists(int id)
        {
            return _context.ServiceUser.Any(e => e.ServiceUserId == id);
        }
    }
}
