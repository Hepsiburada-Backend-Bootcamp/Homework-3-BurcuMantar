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
using Web.Services;
using Xunit;

namespace UnitTest.Web.Services.PatientServiceTests
{
    public class Delete
    {
        private readonly Mock<IAsyncRepository<Patient>> _mockPatientRepository;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        public Delete()
        {
            _mockPatientRepository = new Mock<IAsyncRepository<Patient>>();
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public async Task ShouldInvokePatientRepositoryDeleteOnce()
        {
            _mockPatientRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Patient());
            var patientService = new PatientService(_mockPatientRepository.Object, _mapper);
            await patientService.Delete(It.IsAny<int>());

            _mockPatientRepository.Verify(x => x.Delete(It.IsAny<Patient>()), Times.Once);
        }
    }
}
