using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dtos.Hospital;

namespace Web.Interfaces
{
    public interface IHospitalService
    {
        Task Add(HospitalPostDto hospitalPostDto);
        Task<HospitalDto> GetById(int id);
        Task<List<HospitalDto>> GetAll();
        Task Delete(int id);
        Task Update(HospitalUpdateDto hospitalUpdateDto);
    }
}
