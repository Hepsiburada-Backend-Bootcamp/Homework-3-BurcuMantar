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
using Web.Dtos.Hospital;
using Web.Services;
using Xunit;

namespace UnitTest.Web.Services.HospitalServiceTests
{
    public class Add
    {
        private readonly Mock<IAsyncRepository<Hospital>> _mockHospitalRepository;
        private readonly HospitalPostDto _mockHospitalPostDto;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public Add()
        {
            _mockHospitalRepository = new Mock<IAsyncRepository<Hospital>>();
            _mockHospitalPostDto = new Mock<HospitalPostDto>().Object;
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();
            
        }

        [Fact]
        public async Task ShouldInvokeHospitalRepositoryAddOnce()
        {
            _mockHospitalRepository.Setup(x => x.Add(It.IsAny<Hospital>()))
                .ReturnsAsync(new Hospital());
            var hospitalService = new HospitalService(_mockHospitalRepository.Object, _mapper);
            await hospitalService.Add(_mockHospitalPostDto);
            _mockHospitalRepository.Verify(x => x.Add(It.IsAny<Hospital>()), Times.Once);

        }
    }
}
