using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dtos.Hospital;
using Web.Interfaces;

namespace Web.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Hospital> _hospitalRepository;

        public HospitalService(IAsyncRepository<Hospital> hospitalRepository, IMapper mapper)
        {
            _mapper = mapper;
            _hospitalRepository = hospitalRepository;
        }

        public Task Add(HospitalPostDto hospitalPostDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalPostDto);
            return _hospitalRepository.Add(hospital);
        }

        public Task Delete(int id)
        {
            var hospital = _hospitalRepository.GetById(id);
            return _hospitalRepository.Delete(hospital.Result);
        }

        public async Task<List<HospitalDto>> GetAll()
        {
            List<Hospital> hospitalList = await _hospitalRepository.ListAll();
            List<HospitalDto> hospitals = new List<HospitalDto>();
            foreach (var item in hospitalList)
            {
                var hp = new HospitalDto();
                hp.Id = item.Id;
                hp.Name = item.Name;
                hp.Address = item.Address;
                hospitals.Add(hp);
            }
            return hospitals;
        }

        public async Task<HospitalDto> GetById(int id)
        {
            var hospital = await _hospitalRepository.GetById(id);
            var result = _mapper.Map<HospitalDto>(hospital);
            return result;
        }

        public Task Update(HospitalUpdateDto hospitalUpdateDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalUpdateDto);
            return _hospitalRepository.Update(hospital);
        }
    }
}
