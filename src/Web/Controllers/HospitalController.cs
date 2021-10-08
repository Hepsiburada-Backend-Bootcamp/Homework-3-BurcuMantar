using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dtos.Hospital;
using Web.Interfaces;

namespace Web.Controllers
{
    [Route("api/v3/hospital")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly ILogger<HospitalController> _logger;
        private readonly IHospitalService _hospitalService;

        public HospitalController(ILogger<HospitalController> logger,IHospitalService hospitalService)
        {
            _logger = logger;
            _hospitalService = hospitalService;
        }

        //You can use the HttpGet request to take all hospitalList
        //https://localhost:44392/api/v3/hospital
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("User requested the HospitalController's Get method.");
            var result = await _hospitalService.GetAll();
            return Ok(result);

        }

        //You can use this HttpGet request with id  to get just one hospital object.
        //https://localhost:44392/api/v3/hospitals/3
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("User requested the HospitalController's GetbyId method.");

            var result = await _hospitalService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //You can use this HttpPost request to create new hospital's object.
        //https://localhost:44392/api/v3/hospitals
        [HttpPost]
        public IActionResult Add([FromBody] HospitalPostDto hospitalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var Result = _hospitalService.Add(hospitalDto);
            return CreatedAtAction("Get", new { Id = Result.Id }, hospitalDto);

        }

        //You can use this HttpDelete request to delete hospital's object already have with using unique id.
        //https://localhost:44392/api/v3/hospitals/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _hospitalService.Delete(id);
            return NoContent();
        }


        //You can use this HttpPut request to update hospital's object already have with using unique id.
        //https://localhost:44392/api/v3/hospitals/4
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] HospitalUpdateDto hospitalDto)
        {
            if (id != hospitalDto.Id)
            {
                return BadRequest("Id information is not confirmed");
            }
            _hospitalService.Update(hospitalDto);
            return Ok();
        }
    }
}
