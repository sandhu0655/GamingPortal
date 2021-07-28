using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamingPortal.Data;
using GamingPortal.Models;

namespace GamingPortal.Controllers
{
    public class GmesController : Controller
    {
        private readonly GamingPortalContext _context;

        public GmesController(GamingPortalContext context)
        {
            _context = context;
        }

        // GET: Gmes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gme.ToListAsync());
        }
        public async Task<IActionResult> show()
        {
            return View(await _context.Gme.ToListAsync());
        }
        // GET: Gmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gme = await _context.Gme
                .FirstOrDefaultAsync(m => m.id == id);
            if (gme == null)
            {
                return NotFound();
            }

            return View(gme);
        }

        // GET: Gmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Description,picLink,dLink")] Gme gme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gme);
        }

        // GET: Gmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gme = await _context.Gme.FindAsync(id);
            if (gme == null)
            {
                return NotFound();
            }
            return View(gme);
        }

        // POST: Gmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Description,picLink,dLink")] Gme gme)
        {
            if (id != gme.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GmeExists(gme.id))
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
            return View(gme);
        }

        // GET: Gmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gme = await _context.Gme
                .FirstOrDefaultAsync(m => m.id == id);
            if (gme == null)
            {
                return NotFound();
            }

            return View(gme);
        }

        // POST: Gmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gme = await _context.Gme.FindAsync(id);
            _context.Gme.Remove(gme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GmeExists(int id)
        {
            return _context.Gme.Any(e => e.id == id);
        }
    }
}
