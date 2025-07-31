using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Med_Center.Data
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [ForeignKey("DoctorId")]
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
