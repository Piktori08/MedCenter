using Med_Center.Data;

namespace Med_Center.Models
{
    public class PatientForEdit
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? DoctorId { get; set; }
        public int? SelectedDoctorId { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
