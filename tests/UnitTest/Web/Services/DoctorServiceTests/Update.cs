using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web;
using Web.Dtos;
using Web.Services;
using Xunit;

namespace UnitTest.Web.Services.DoctorServiceTests
{
    public class Update
    {
        private readonly Mock<IAsyncRepository<Doctor>> _mockDoctorRepository;
        private readonly DoctorUpdateDto _mockDoctorUpdateDto;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public Update()
        {
            _mockDoctorRepository = new Mock<IAsyncRepository<Doctor>>();
            _mockDoctorUpdateDto = new Mock<DoctorUpdateDto>().Object;
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();
           
        }

        [Fact]
        public async Task ShouldInvokeDoctorRepositoryUpdateOnce()
        {
            var doctorService = new DoctorService(_mockDoctorRepository.Object, _mapper);
            await doctorService.Update(_mockDoctorUpdateDto);
            _mockDoctorRepository.Verify(x => x.Update(It.IsAny<Doctor>()), Times.Once);
        }
    }
}
