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
    public class TypeOfUsersController : Controller
    {
        private readonly wasteManagementContext _context;

        public TypeOfUsersController(wasteManagementContext context)
        {
            _context = context;
        }

        // GET: TypeOfUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOfUser.ToListAsync());
        }

        // GET: TypeOfUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfUser = await _context.TypeOfUser
                .FirstOrDefaultAsync(m => m.TypeOfUserId == id);
            if (typeOfUser == null)
            {
                return NotFound();
            }

            return View(typeOfUser);
        }

        // GET: TypeOfUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfUserId,TypeOfUserName")] TypeOfUser typeOfUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfUser);
        }

        // GET: TypeOfUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfUser = await _context.TypeOfUser.FindAsync(id);
            if (typeOfUser == null)
            {
                return NotFound();
            }
            return View(typeOfUser);
        }

        // POST: TypeOfUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeOfUserId,TypeOfUserName")] TypeOfUser typeOfUser)
        {
            if (id != typeOfUser.TypeOfUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfUserExists(typeOfUser.TypeOfUserId))
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
            return View(typeOfUser);
        }

        // GET: TypeOfUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfUser = await _context.TypeOfUser
                .FirstOrDefaultAsync(m => m.TypeOfUserId == id);
            if (typeOfUser == null)
            {
                return NotFound();
            }

            return View(typeOfUser);
        }

        // POST: TypeOfUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfUser = await _context.TypeOfUser.FindAsync(id);
            _context.TypeOfUser.Remove(typeOfUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfUserExists(int id)
        {
            return _context.TypeOfUser.Any(e => e.TypeOfUserId == id);
        }
    }
}
