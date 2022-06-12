using DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly StorageDbContext _context;
        public ProductsController(StorageDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> IndexAsync()
        {
            var products = await _context.Products.ToListAsync();

            foreach (var item in products)
            {
                item.Staff = _context.Staffs.FirstOrDefault(t => t.Id == item.StaffId);
                item.Maker = _context.Makers.FirstOrDefault(t => t.Id == item.MakerId);
                item.ProductType = _context.ProductTypes.FirstOrDefault(t => t.Id == item.ProductTypeId);
            }
            return View(products);
        }


        public ActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name");
            ViewData["MakerId"] = new SelectList(_context.Makers, "Id", "Country");
            ViewData["StaffId"] = new SelectList(_context.Staffs, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name,Quantity,Standart,ExpiryDate,ProductTypeId,MakerId,StaffId,Id")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name",product.ProductTypeId);
            ViewData["MakerId"] = new SelectList(_context.Makers, "Id", "Country",product.MakerId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "Id", "Name",product.StaffId);
            return View(product);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewData["MakerId"] = new SelectList(_context.Makers, "Id", "Name", product.MakerId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "Id", "Name", product.StaffId);
            return View(product);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Quantity,Standart,ExpiryDate,ProductTypeId,MakerId,StaffId,Id")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewData["MakerId"] = new SelectList(_context.Makers, "Id", "Name", product.MakerId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "Id", "Name", product.StaffId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(u => u.Staff)
                .Include(u => u.ProductType)
                .Include(u=>u.Maker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
