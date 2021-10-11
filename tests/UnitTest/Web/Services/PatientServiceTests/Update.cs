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
using Web.Dtos.Patient;
using Web.Services;
using Xunit;

namespace UnitTest.Web.Services.PatientServiceTests
{
    public class Update
    {
        private readonly Mock<IAsyncRepository<Patient>> _mockPatientRepository;
        private readonly PatientUpdateDto _mockPatientUpdateDto;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public Update()
        {
            _mockPatientRepository = new Mock<IAsyncRepository<Patient>>();
            _mockPatientUpdateDto = new Mock<PatientUpdateDto>().Object;
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();

        }

        [Fact]
        public async Task ShouldInvokePatientRepositoryUpdateOnce()
        {
            var patientService = new PatientService(_mockPatientRepository.Object, _mapper);
            await patientService.Update(_mockPatientUpdateDto);
            _mockPatientRepository.Verify(x => x.Update(It.IsAny<Patient>()), Times.Once);
        }
    }
}
