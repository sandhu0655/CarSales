using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSales.Data;
using CarSales.Models;

namespace CarSales.Controllers
{
    public class LoginsController : Controller
    {
        private readonly CarSalesContext _context;

        public LoginsController(CarSalesContext context)
        {
            _context = context;
        }

        // GET: Logins/Create

        public IActionResult LoginArea()
        {
            return View();
        }

        public IActionResult Erorr()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin([Bind("Id,UserName,Password")] Login login)
        {
            if(login.UserName == "User" && login.Password == "12345")
            {
                return RedirectToAction("Admin", "Home");
            }
            else
            {
                return RedirectToAction(nameof(AdminLogin));
            }
        }
    }
}
