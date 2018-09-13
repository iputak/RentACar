using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Models;

namespace RentACar.Controllers
{
    public class AutisController : Controller
    {
        private readonly RentACarContext _context;

        public AutisController(RentACarContext context)
        {
            _context = context;
        }

        // GET: Autis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auti.ToListAsync());
        }

        // GET: Autis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auti = await _context.Auti
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auti == null)
            {
                return NotFound();
            }

            return View(auti);
        }

        // GET: Autis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Auti auti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auti);
        }

        // GET: Autis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auti = await _context.Auti.FindAsync(id);
            if (auti == null)
            {
                return NotFound();
            }
            return View(auti);
        }

        // POST: Autis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Auti auti)
        {
            if (id != auti.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutiExists(auti.ID))
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
            return View(auti);
        }

        // GET: Autis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auti = await _context.Auti
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auti == null)
            {
                return NotFound();
            }

            return View(auti);
        }

        // POST: Autis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auti = await _context.Auti.FindAsync(id);
            _context.Auti.Remove(auti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutiExists(int id)
        {
            return _context.Auti.Any(e => e.ID == id);
        }
    }
}
