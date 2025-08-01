using Med_Center.Data;

namespace Med_Center.Models
{
    public class AppointmentForEdit
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Date { get; set; }

        public int? DoctorId { get; set; }
        public string DoctorName { get; set; }

        public int? PatientId { get; set; }
        public string PatientName { get; set; }

        public int? SelectedDoctorId { get; set; }
        public List<Doctor> Doctors { get; set; }

        public int? SelectedPatientId { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
