using DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagement.Controllers
{
    public class MakersController : Controller
    {
        private readonly StorageDbContext _context;
        public MakersController(StorageDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var makers = _context.Makers.ToList();
            return View(makers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name,Country,Experience,Id")] Maker maker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maker);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = await _context.Makers.FindAsync(id);
            if (maker == null)
            {
                return NotFound();
            }
            return View(maker);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Country,Experience,Id")] Maker maker)
        {
            if (id != maker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakerExists(maker.Id))
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
            return View(maker);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maker = await _context.Makers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maker == null)
            {
                return NotFound();
            }
            return View(maker);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maker = await _context.Makers.FindAsync(id);
            _context.Makers.Remove(maker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool MakerExists(int id)
        {
            return _context.Makers.Any(e => e.Id == id);
        }
    }
}
