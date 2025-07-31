using Med_Center.Data;

namespace Med_Center.Models
{
    public class PatientForCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? SelectedDoctorId { get; set; }
        public List <Doctor> Doctors { get; set; }
    }
}
