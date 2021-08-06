﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSales.Data;
using CarSales.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.Controllers
{
    namespace CarSales.Controllers
    {
        public class ContactUsController : Controller
        {
            private readonly CarSalesContext _context;

            public ContactUsController(CarSalesContext context)
            {
                _context = context;
            }

            // GET: ContactUs
            public async Task<IActionResult> Index()
            {
                return View(await _context.ContactUs.ToListAsync());
            }

            // GET: ContactUs/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var ContactUs = await _context.ContactUs
                    .FirstOrDefaultAsync(m => m.id == id);
                if (ContactUs == null)
                {
                    return NotFound();
                }

                return View(ContactUs);
            }

            public IActionResult Display()
            {
                return View();
            }

            // GET: ContactUs/Create
            public IActionResult Create()
            {
                return View();
            }
            
            // POST: ContactUs/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Email,Message")] ContactUs ContactUs)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(ContactUs);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Display));
                }
                return View(ContactUs);
            }

            // GET: ContactUs/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var ContactUs = await _context.ContactUs.FindAsync(id);
                if (ContactUs == null)
                {
                    return NotFound();
                }
                return View(ContactUs);
            }

            // POST: ContactUs/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Message")] ContactUs ContactUs)
            {
                if (id != ContactUs.id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(ContactUs);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ContactUsExists(ContactUs.id))
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
                return View(ContactUs);
            }

            // GET: ContactUs/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var ContactUs = await _context.ContactUs
                    .FirstOrDefaultAsync(m => m.id == id);
                if (ContactUs == null)
                {
                    return NotFound();
                }

                return View(ContactUs);
            }

            // POST: ContactUs/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var ContactUs = await _context.ContactUs.FindAsync(id);
                _context.ContactUs.Remove(ContactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ContactUsExists(int id)
            {
                return _context.ContactUs.Any(e => e.id == id);
            }
        }
    }
}