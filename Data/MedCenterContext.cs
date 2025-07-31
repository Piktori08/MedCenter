using Microsoft.EntityFrameworkCore;

namespace Med_Center.Data
{
    public class MedCenterContext : DbContext
    {
        public MedCenterContext(DbContextOptions<MedCenterContext> options) : base(options) { }

        public DbSet <Doctor> Doctors { get; set; }
        public DbSet <Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Patient>()
                .HasOne(d => d.Doctor)
                .WithMany(p => p.Patients)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
