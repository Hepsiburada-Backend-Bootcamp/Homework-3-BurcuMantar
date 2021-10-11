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
    public class Update
    {
        private readonly Mock<IAsyncRepository<Hospital>> _mockHospitalRepository;
        private readonly HospitalUpdateDto _mockHospitalUpdateDto;
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        public Update()
        {
            _mockHospitalRepository = new Mock<IAsyncRepository<Hospital>>();
            _mockHospitalUpdateDto = new Mock<HospitalUpdateDto>().Object;
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });
            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public async Task ShouldInvokeHospitalRepositoryUpdateOnce()
        {
            var hospitalService = new HospitalService(_mockHospitalRepository.Object, _mapper);
            await hospitalService.Update(_mockHospitalUpdateDto);
            _mockHospitalRepository.Verify(x => x.Update(It.IsAny<Hospital>()), Times.Once);
        }
    }
}
