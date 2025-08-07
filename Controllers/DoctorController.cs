using Med_Center.Data;
using Med_Center.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Med_Center.Controllers;

namespace Med_Center.Controllers
{
    public class DoctorController : Controller
    {
        private readonly MedCenterContext _context;
        public DoctorController(MedCenterContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return View(doctors);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new DoctorForCreation();
            return View(model);
        }
        [HttpPost]
        
        public async Task<IActionResult> Create(DoctorForCreation model)
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            var model = new DoctorForEdit()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Age = doctor.Age
            };
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(DoctorForEdit model)
        {
            var doctors = new Doctor()
            {
                Id = model.Id,
                Age = model.Age,
                Name = model.Name,
            };
            _context.Doctors.Update(doctors);
            await _context.SaveChangesAsync();

            var appointmentsToUpdate = await _context.Appointments
                .Where(a => a.DoctorId == model.Id)
                .ToListAsync();

            foreach (var appointment in appointmentsToUpdate)
            {
                appointment.DoctorName = model.Name;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
