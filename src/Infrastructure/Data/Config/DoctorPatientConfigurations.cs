using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DoctorPatientConfigurations : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> builder)
        {
            builder.HasKey(dp => new { dp.DoctorId, dp.PatientId });
            builder.HasOne(x => x.Doctor).WithMany(x => x.DoctorPatients).HasForeignKey(x => x.DoctorId);
            builder.HasOne(x => x.Patient).WithMany(x => x.DoctorPatients).HasForeignKey(x => x.PatientId);
        }
    }
}
