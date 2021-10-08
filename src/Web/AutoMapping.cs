using ApplicationCore.Entities;
using AutoMapper;
using Web.Dtos;
using Web.Dtos.Hospital;
using Web.Dtos.Patient;

namespace Web
{
    public class AutoMapping :Profile
    {
        public AutoMapping()
        {
            CreateMap<BaseEntity, BaseDto>().IncludeAllDerived();

            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();
            CreateMap<Doctor, DoctorPostDto>();
            CreateMap<DoctorPostDto, Doctor>();
            CreateMap<Doctor, DoctorUpdateDto>();
            CreateMap<DoctorUpdateDto, Doctor>();

            CreateMap<Hospital, HospitalDto>();
            CreateMap<HospitalDto, Hospital>();
            CreateMap<Hospital, HospitalUpdateDto>();
            CreateMap<HospitalUpdateDto, Hospital>();
            CreateMap<Hospital, HospitalPostDto>();
            CreateMap<HospitalPostDto, Hospital>();

            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();
            CreateMap<Patient, PatientUpdateDto>();
            CreateMap<PatientUpdateDto, Patient>();
            CreateMap<Patient, PatientPostDto>();
            CreateMap<PatientPostDto, Patient>();

            CreateMap<DoctorPatient, DoctorPatientDto>();
            CreateMap<DoctorPatientDto, DoctorPatient>();
        }
    }
}
