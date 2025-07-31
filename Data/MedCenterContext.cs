using Microsoft.EntityFrameworkCore;

namespace Med_Center.Data
{
    public class MedCenterContext : DbContext
    {
        public MedCenterContext(DbContextOptions<MedCenterContext> options) : base(options) { }

        public DbSet <Doctor> Doctors { get; set; }
    }
}
