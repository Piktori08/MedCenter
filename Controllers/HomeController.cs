using System.Data.Common;

using System.Linq;
using System.Diagnostics;
using Med_Center.Data;
using Med_Center.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var appointments = await _context.Appointments.ToListAsync();
            ViewBag.Appointments = appointments;
            var dMax = appointments.GroupBy(a => a.DoctorId).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;
            var doktori = await _context.Doctors.FindAsync(dMax);
            ViewBag.doktoriName = doktori?.Name;
            var pMax = appointments.GroupBy(a => a.PatientId).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;
            var pacienti = await _context.Patients.FindAsync(pMax);
            ViewBag.pacientName = pacienti?.FirstName + " " + pacienti?.LastName;
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
