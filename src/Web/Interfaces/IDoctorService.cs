using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dtos;

namespace Web.Interfaces
{
    public interface IDoctorService
    {
        Task Create(DoctorPostDto drPostDto);
        Task<DoctorDto> GetById(int id);
        Task<List<DoctorDto>> GetAll();
        Task Delete(int id);
        Task Update(DoctorUpdateDto drUpdateDto);
    }
}
