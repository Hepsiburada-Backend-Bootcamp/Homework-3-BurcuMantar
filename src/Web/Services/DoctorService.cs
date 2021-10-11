using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dtos;
using Web.Interfaces;

namespace Web.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IAsyncRepository<Doctor> _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IAsyncRepository<Doctor> doctorRepository,IMapper mapper )
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public Task Create(DoctorPostDto drPostDto)
        {
            var doctor = _mapper.Map<Doctor>(drPostDto);
            if (doctor == null) throw new NullReferenceException("Doctor object is null.");
            return _doctorRepository.Add(doctor);
        }

        public Task Delete(int id)
        {
            var doctor = _doctorRepository.GetById(id);
            return _doctorRepository.Delete(doctor.Result);
        }

        public async Task<List<DoctorDto>> GetAll()
        {
            List<Doctor> drlist = await _doctorRepository.ListAll();
            List<DoctorDto> doctors = new List<DoctorDto>();
            foreach (var item in drlist)
            {
                var dr = new DoctorDto();
                dr.Id = item.Id;
                dr.Name = item.Name;
                dr.LastName = item.LastName;
                dr.Gender = item.Gender;
                dr.Clinic = item.Clinic;
                dr.HospitalId = item.HospitalId;
                doctors.Add(dr);
            }
            return doctors;
        }

        public async Task<DoctorDto> GetById(int id)
        {
            var doctor = await _doctorRepository.GetById(id);
            var result = _mapper.Map<DoctorDto>(doctor);
            return result;
        }

        public Task Update(DoctorUpdateDto drUpdateDto)
        {
            var doctor = _mapper.Map<Doctor>(drUpdateDto);
            return _doctorRepository.Update(doctor);
        }
    }
}
