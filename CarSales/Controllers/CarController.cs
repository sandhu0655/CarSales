using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSales.Data;
using CarSales.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace CarSales.Controllers
{
        public class CarController : Controller
        {
            private readonly CarSalesContext _context;

            public CarController(CarSalesContext context)
            {
                _context = context;
            }

            // GET: Car
            public async Task<IActionResult> Index()
            {
                
                    return View(await _context.Car.ToListAsync());
            }

            public async Task<IActionResult> UserView()
            {
                
                    return View(await _context.Car.ToListAsync());
            }
        
            // GET: Car/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Car = await _context.Car
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Car == null)
                {
                    return NotFound();
                }

                return View(Car);
            }

            // GET: Car/Create
            public IActionResult Display()
            {
                return View();
            }
        
            // GET: Car/Create
            public IActionResult AddCar()
            {
                return View();
            }

            // POST: Car/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> AddCar([Bind("Id,CarName,CarModel,Price")] Car Car)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Car);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Display));
                }
                return View(Car);
            }
        
            // GET: Car/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Car/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,CarName,CarModel,Price")] Car Car)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Car);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Car);
            }

            // GET: Car/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Car = await _context.Car.FindAsync(id);
                if (Car == null)
                {
                    return NotFound();
                }
                return View(Car);
            }

            // POST: Car/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,CarName,CarModel,Price")] Car Car)
            {
                if (id != Car.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Car);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CarExists(Car.Id))
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
                return View(Car);
            }

            // GET: Car/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Car = await _context.Car
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Car == null)
                {
                    return NotFound();
                }

                return View(Car);
            }

            // POST: Car/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Car = await _context.Car.FindAsync(id);
                _context.Car.Remove(Car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool CarExists(int id)
            {
                return _context.Car.Any(e => e.Id == id);
            }
        }
    }