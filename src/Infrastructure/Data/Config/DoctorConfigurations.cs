using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Clinic).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Hospital).WithMany(x => x.Doctors).HasForeignKey(x => x.HospitalId);
        }
    }
}
