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

namespace UnitTest.Web.Services.HospitalServiceTests
{
    public class Delete
    {
        private readonly Mock<IAsyncRepository<Hospital>> _mockHospitalRepository;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public Delete()
        {
            _mockHospitalRepository = new Mock<IAsyncRepository<Hospital>>();
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public async Task ShouldInvokeHospitalRepositoryDeleteOnce()
        {
            _mockHospitalRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Hospital());
            var hospitalService = new HospitalService(_mockHospitalRepository.Object, _mapper);
            await hospitalService.Delete(It.IsAny<int>());

            _mockHospitalRepository.Verify(x => x.Delete(It.IsAny<Hospital>()), Times.Once);
        }
    }
}
