using Med_Center.Data;
using Med_Center.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Med_Center.Controllers
{
    public class PatientController : Controller
    {
        private readonly MedCenterContext _context;
        public PatientController(MedCenterContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var patients = await _context.Patients.Include(d=>d.Doctor).ToListAsync();
            return View(patients);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new PatientForCreation();
            model.Doctors = await _context.Doctors.ToListAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(PatientForCreation model)
        {
            var patient = new Patient()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                DoctorId = model.SelectedDoctorId
            };
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            var model = new PatientForEdit()
            {
                Id = id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                SelectedDoctorId = patient.DoctorId,
                Doctors = await _context.Doctors.ToListAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(PatientForEdit model)
        {
            var patient = new Patient()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                DoctorId = model.SelectedDoctorId
            };
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
