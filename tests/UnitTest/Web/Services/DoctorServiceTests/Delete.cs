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
    public class Delete
    {
        private readonly Mock<IAsyncRepository<Doctor>> _mockDoctorRepository;
        private readonly DoctorPostDto _mockDoctorPostDto;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        private readonly Doctor _mockDr;

        public Delete()
        {
            _mockDoctorRepository = new Mock<IAsyncRepository<Doctor>>();
            _mockDoctorPostDto = new Mock<DoctorPostDto>().Object;
            _mockDr = new Mock<Doctor>().Object;
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();

            _mockDoctorPostDto.Name = "Kagan";
            _mockDoctorPostDto.LastName = "Dumbaracı";
            _mockDoctorPostDto.Gender = "M";
            _mockDoctorPostDto.Clinic = "Acil";
            _mockDoctorPostDto.HospitalId = 1;
        }

        [Fact]
        public async Task ShouldInvokeDoctorRepositoryDeleteOnce()
        {
            _mockDoctorRepository.Setup(x => x.GetById(It.IsAny<int>()))
                                 .ReturnsAsync(new Doctor());
            var doctorService = new DoctorService(_mockDoctorRepository.Object, _mapper);
            await doctorService.Delete(It.IsAny<int>());
            _mockDoctorRepository.Verify(x => x.Delete(It.IsAny<Doctor>()), Times.Once);
        }
    }
}
