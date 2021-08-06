using CarSales.Data;
using CarSales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.Controllers
{
    public class BookingCarsController : Controller
    {
            private readonly CarSalesContext _context;

            public BookingCarsController(CarSalesContext context)
            {
                _context = context;
            }

            // GET: BookingCars
            public async Task<IActionResult> Index()
            {
                return View(await _context.BookingCars.ToListAsync());
            }

            // GET: BookingCars/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var BookingCars = await _context.BookingCars
                    .FirstOrDefaultAsync(m => m.id == id);
                if (BookingCars == null)
                {
                    return NotFound();
                }

                return View(BookingCars);
            }
            public IActionResult CarModeltFound()
            {
                return View();
            }
            public IActionResult CarBooked()
            {
                return View();
            }
            public IActionResult CarNotFound()
            {
                return View();
            }

            // GET: BookingCars/Create
            public IActionResult Create()
            {
                var Cars = _context.Car.ToList();
                if (Cars.Count > 0)
                {
                    Cars.Insert(0, new Car { Id = 0, CarName = "Select Car" });
                    ViewBag.ListCars = Cars;
                    return View();
                }
                else
                {
                    return RedirectToAction(nameof(CarNotFound));
                }
            }



            // POST: BookingCars/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Contact,CarModel,BookingDate,CarId")] BookingCars BookingCars)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(BookingCars);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CarBooked));
                }
                return View(BookingCars);
            }

            // GET: BookingCars/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var BookingCars = await _context.BookingCars.FindAsync(id);
                if (BookingCars == null)
                {
                    return NotFound();
                }
                return View(BookingCars);
            }

            // POST: BookingCars/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,CarModel,BookingDate,CarId")] BookingCars BookingCars)
            {
                if (id != BookingCars.id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(BookingCars);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BookingCarsExists(BookingCars.id))
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
                return View(BookingCars);
            }

            // GET: BookingCars/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var BookingCars = await _context.BookingCars
                    .FirstOrDefaultAsync(m => m.id == id);
                if (BookingCars == null)
                {
                    return NotFound();
                }

                return View(BookingCars);
            }

            // POST: BookingCars/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var BookingCars = await _context.BookingCars.FindAsync(id);
                _context.BookingCars.Remove(BookingCars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool BookingCarsExists(int id)
            {
                return _context.BookingCars.Any(e => e.id == id);
            }
        }
    }
