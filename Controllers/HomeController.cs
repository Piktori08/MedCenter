using Med_Center.Data;
using Med_Center.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;

namespace Med_Center.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MedCenterContext _context;

        public HomeController(ILogger<HomeController> logger, MedCenterContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Doctors = await _context.Doctors.ToListAsync();
            var Patients = await _context.Patients.ToListAsync();
            var dMax = Doctors.Max(d => d.AppointmentCount);
            var docs = Doctors.Where(d => d.AppointmentCount == dMax).ToList();
            ViewBag.Doctors = docs;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
