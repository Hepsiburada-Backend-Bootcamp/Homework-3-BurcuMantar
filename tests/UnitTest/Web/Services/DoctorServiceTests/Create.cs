using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using Web;
using Web.Dtos;
using Web.Services;
using Xunit;

namespace UnitTest.Web.Services.DoctorServiceTests
{
    public class Create
    {
        private readonly Mock<IAsyncRepository<Doctor>> _mockDoctorRepository;
        private readonly DoctorPostDto _mockDoctorPostDto;
        private readonly DoctorPostDto _mockDoctorPostDto2;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        public Create()
        {
            _mockDoctorRepository = new Mock<IAsyncRepository<Doctor>>();
            _mockDoctorPostDto = new Mock<DoctorPostDto>().Object;
            _mockDoctorPostDto2 = new Mock<DoctorPostDto>().Object;
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();
            _mockDoctorPostDto = null;

            //To take Fail feedback active below codes

            _mockDoctorPostDto2.Name = "Kagan";
            _mockDoctorPostDto2.LastName = "Dumbaracı";
            _mockDoctorPostDto2.Gender = "M";
            _mockDoctorPostDto2.Clinic = "Acil";
            _mockDoctorPostDto2.HospitalId = 1;
        }
        [Fact]
        public async Task ThrowNullReferenceExceptionWhenObjectIsNull()
        {
            var doctorService = new DoctorService(_mockDoctorRepository.Object, _mapper);

            Assert.Throws<NullReferenceException>(() =>
            {
                doctorService.Create(_mockDoctorPostDto);

            });
        }

        [Fact]
        public async Task ShouldInvokeDoctorRepositoryAddOnce()
        {
            _mockDoctorRepository.Setup(x => x.Add(It.IsAny<Doctor>()))
                .ReturnsAsync(new Doctor());
            var doctorService = new DoctorService(_mockDoctorRepository.Object, _mapper);
            await doctorService.Create(_mockDoctorPostDto2);

            _mockDoctorRepository.Verify(x => x.Add(It.IsAny<Doctor>()), Times.Once);
        }
    }
}
