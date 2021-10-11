using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Moq;
using System.Threading.Tasks;
using Web;
using Web.Dtos.Patient;
using Web.Services;
using Xunit;

namespace UnitTest.Web.Services.PatientServiceTests
{
    public class Add
    {
        private readonly Mock<IAsyncRepository<Patient>> _mockPatientRepository;
        private readonly PatientPostDto _mockPatientPostDto;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        public Add()
        {
            _mockPatientRepository = new Mock<IAsyncRepository<Patient>>();
            _mockPatientPostDto = new Mock<PatientPostDto>().Object;
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();

        }

        [Fact]
        public async Task ShouldInvokePatientRepositoryAddOnce()
        {
            _mockPatientRepository.Setup(x => x.Add(It.IsAny<Patient>()))
                .ReturnsAsync(new Patient());
            var patientService = new PatientService(_mockPatientRepository.Object, _mapper);
            await patientService.Add(_mockPatientPostDto);
            _mockPatientRepository.Verify(x => x.Add(It.IsAny<Patient>()), Times.Once);

        }
    }
}
