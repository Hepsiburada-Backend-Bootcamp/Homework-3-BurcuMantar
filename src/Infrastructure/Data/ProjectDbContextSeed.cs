using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProjectDbContextSeed
    {
        public static async Task SeedAsync(ProjectDbContext db)
        {
            if (await db.Doctors.AnyAsync() || await db.Hospitals.AnyAsync() || await db.Patients.AnyAsync() || await db.DoctorPatients.AnyAsync()) return;

            var p1 = new Patient() { Id = 1, Name = "Veli", LastName = "Ak", Gender = "M", FileNumber = 1122334455 };
            var p2 = new Patient() { Id = 2, Name = "Ece", LastName = "Aka", Gender = "F", FileNumber = 1528745889 };
            var p3 = new Patient() { Id = 3, Name = "Ege", LastName = "Akar", Gender = "M", FileNumber = 9988776655 };
            db.AddRange(p1, p2, p3);

            var d1 = new Doctor() { Id = 1, Name = "Ali", LastName = "Ak", Gender = "M", HospitalId = 1, Clinic = "Genel Cerrahi" };
            var d2 = new Doctor() { Id = 2, Name = "Can", LastName = "Aka", Gender = "M", HospitalId = 3, Clinic = "Göz Hastaliklari" };
            var d3 = new Doctor() { Id = 3, Name = "Cem", LastName = "Akar", Gender = "M", HospitalId = 2, Clinic = "Dahiliye" };
            var d4 = new Doctor() { Id = 4, Name = "Han", LastName = "Gök", Gender = "M", HospitalId = 1, Clinic = "Pediatri" };
            var d5 = new Doctor() { Id = 5, Name = "Naz", LastName = "Karlı", Gender = "F", HospitalId = 3, Clinic = "Göz Hastaliklari" };
            var d6 = new Doctor() { Id = 6, Name = "Gaye", LastName = "Sucu", Gender = "F", HospitalId = 2, Clinic = "Cildiye" };
            db.AddRange(d1, d2, d3, d4, d5, d6);

            var h1 = new Hospital() { Id = 1, Name = "Acıbadem", Address = "Ankara"};
            var h2 = new Hospital() { Id = 2, Name = "Liv Hospital", Address = "İstanbul" };
            var h3 = new Hospital() { Id = 3, Name = "Başkent", Address = "İzmir"};
            db.AddRange(h1, h2, h3);


            var dp1 = new DoctorPatient() { DoctorId = 1, PatientId = 3 };
            var dp2 = new DoctorPatient() { DoctorId = 1, PatientId = 1 };
            var dp3 = new DoctorPatient() { DoctorId = 3, PatientId = 2 };
            var dp4 = new DoctorPatient() { DoctorId = 3, PatientId = 1 };
            var dp5 = new DoctorPatient() { DoctorId = 5, PatientId = 3 };
            var dp6 = new DoctorPatient() { DoctorId = 4, PatientId = 2 };
            db.AddRange(dp1, dp2, dp3, dp4, dp5, dp6);

            await db.SaveChangesAsync();

        }
    }
}
