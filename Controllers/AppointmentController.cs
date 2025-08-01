using Med_Center.Data;
using Med_Center.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Med_Center.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly MedCenterContext _context;
        public AppointmentController(MedCenterContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return View(appointments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new AppointmentForCreation();
            model.Doctors = await _context.Doctors.ToListAsync();
            model.Patients = await _context.Patients.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentForCreation model)
        {
            var dName = await _context.Doctors.Where(d => d.Id == model.DoctorId).Select(d => d.Name).FirstOrDefaultAsync();
            var pName = await _context.Patients.Where(d => d.Id == model.PatientId).Select(d => d.FirstName + " " + d.LastName).FirstOrDefaultAsync();

            var appointment = new Appointment()
            {
                No = "",
                Date = DateTime.ParseExact(model.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DoctorId = model.DoctorId,
                DoctorName = dName!,
                PatientId = model.PatientId,
                PatientName = pName!,
            };

            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();

            appointment.No = $"{appointment.Id}-appointment";

            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            var model = new AppointmentForEdit()
            {
                Id = id,
                No = appointment.No,
                Date = appointment.Date.ToString("dd/MM/yyyy"),
                SelectedDoctorId = appointment.DoctorId,
                DoctorName = appointment.DoctorName,
                SelectedPatientId = appointment.PatientId,
                PatientName = appointment.PatientName,
                Doctors = await _context.Doctors.ToListAsync(),
                Patients = await _context.Patients.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppointmentForEdit model)
        {
            var dName = await _context.Doctors.Where(d => d.Id == model.DoctorId).Select(d => d.Name).FirstOrDefaultAsync();
            var pName = await _context.Patients.Where(d => d.Id == model.PatientId).Select(d => d.FirstName + " " + d.LastName).FirstOrDefaultAsync();

            var appointment = new Appointment()
            {
                Id = model.Id,
                No = model.No,
                Date = DateTime.ParseExact(model.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DoctorId = model.DoctorId,
                DoctorName = dName!,
                PatientId = model.PatientId,
                PatientName = pName!,
            };
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
