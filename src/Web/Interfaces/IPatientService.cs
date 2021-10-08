using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dtos.Patient;

namespace Web.Interfaces
{
    public interface IPatientService
    {
        Task Add(PatientPostDto patientPostDto);
        Task<PatientDto> GetById(int id);
        Task<List<PatientDto>> GetAll();
        Task Delete(int id);
        Task Update(PatientUpdateDto patientUpdateDto);
    }
}
