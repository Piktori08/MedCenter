using Med_Center.Data;
using Med_Center.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Med_Center.Controllers
{
    public class DoctorController : Controller
    {
        private readonly MedCenterContext _context;
        public DoctorController(MedCenterContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return View(doctors);
        }
        [HttpGet]
        public async Task <ActionResult> Create()
        {
            var model = new DoctorForCreation();
            return View(model);
        }
        [HttpPost]
        
        public async Task <ActionResult> Create(DoctorForCreation model)
        {
            var doctors = new Doctor()
            {
                Age = model.Age,
                Name = model.Name,
            };
            await _context.Doctors.AddAsync(doctors);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
