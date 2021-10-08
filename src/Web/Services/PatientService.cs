using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dtos.Patient;
using Web.Interfaces;

namespace Web.Services
{
    public class PatientService : IPatientService
    {
        private readonly IAsyncRepository<Patient> _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IAsyncRepository<Patient> patientRepository,IMapper mapper)
        {
           _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public Task Add(PatientPostDto patientPostDto)
        {
            var patient = _mapper.Map<Patient>(patientPostDto);
            return _patientRepository.Add(patient);
        }

        public Task Delete(int id)
        {
            var patient = _patientRepository.GetById(id);
            return _patientRepository.Delete(patient.Result);
        }

        public async Task<List<PatientDto>> GetAll()
        {
            List<Patient> patientList = await _patientRepository.ListAll();
            List<PatientDto> patients = new List<PatientDto>();
            foreach (var item in patientList)
            {
                var pt = new PatientDto();
                pt.Id = item.Id;
                pt.Name = item.Name;
                pt.LastName = item.LastName;
                pt.Gender = item.Gender;
                pt.FileNumber = item.FileNumber;
                patients.Add(pt);
            }
            return patients;
        }

        public async Task<PatientDto> GetById(int id)
        {
            var patient = _patientRepository.GetById(id);
            var result = _mapper.Map<PatientDto>(patient);
            return result;
        }

        public Task Update(PatientUpdateDto patientUpdateDto)
        {
            var patient = _mapper.Map<Patient>(patientUpdateDto);
            return _patientRepository.Update(patient);
        }
    }
}
