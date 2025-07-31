namespace Med_Center.Data
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public IEnumerable <Patient> Patients { get; set; }
    }
}
