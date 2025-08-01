﻿namespace Med_Center.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        public string No { get; set; }
        public DateTime Date { get; set; }


        public int? DoctorId { get; set; }
        public string DoctorName { get; set; }

        public int? PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
