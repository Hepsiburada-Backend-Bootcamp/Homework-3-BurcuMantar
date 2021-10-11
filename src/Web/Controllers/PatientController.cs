using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dtos.Patient;
using Web.Interfaces;

namespace Web.Controllers
{
    [Route("api/v3/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger,IPatientService patientService)
        {
           _logger = logger;
           _patientService = patientService;
        }

        //You can use the HttpGet request to take all patientlist
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("User requested the PatientController's Get method.");
            var result = _patientService.GetAll();
            return Ok(result);

        }

        //You can use this HttpGet request with id  to get just one patient object.
        //https://localhost:44392/api/v3/patients/2
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("User requested the PatientController's GetbyId method.");

            var result = _patientService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //You can use this HttpPost request to create new patient's object.
        //https://localhost:44392/api/v3/patients
        [HttpPost]
        public IActionResult Add([FromBody] PatientPostDto patientPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var Result = _patientService.Add(patientPostDto);
            return CreatedAtAction("Get", new { Id = Result.Id }, patientPostDto);
        }

        //You can use this HttpDelete request to delete patient's object already have with using unique id.
        //https://localhost:44392/api/v3/patients/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _patientService.Delete(id);
            return NoContent();
        }

        //You can use this HttpPut request to update patient's object already have with using unique id.
        //https://localhost:44392/api/v3/patients/5
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody]PatientUpdateDto patientUpdateDto)
        {
            if (id != patientUpdateDto.Id)
            {
                return BadRequest("Id information is not confirmed");
            }
            _patientService.Update(patientUpdateDto);
            return Ok();
        }
    }
}
